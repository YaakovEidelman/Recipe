namespace RecipeSystem
{
    public class RecipeProject
    {

        public static DataTable GetAnyDataTable(string sproc, params (string param, object val)[] paramval)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(sproc);
            if (cmd.Parameters.Count > 0)
            {
                foreach ((string param, object val) p in paramval)
                {
                    if (cmd.Parameters.Contains(p.param))
                    {
                        SQLUtility.SetParamValue(cmd, p.param, p.val);
                    }
                }
            }
            return SQLUtility.GetDataTable(cmd);
        }

        public static void Save(DataTable dt, string sproc)
        {
            if(dt.Rows.Count > 0)
            {
                SQLUtility.SaveDataRow(dt.Rows[0], sproc);
            }
        }

        public static void SaveSubTable(DataTable dt, int? id, string sproc, string col)
        {
            Array rows = dt.Select("", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent);
            foreach (DataRow r in rows)
            {
                if (id != null)
                {
                    r[col] = id;
                }
                SQLUtility.SaveDataRow(r, sproc, false);
            }
            dt.AcceptChanges();
        }
        public static void Delete(DataTable dt, string colname, string sproc)
        {
            int id = 0;
            if (dt.Rows.Count > 0 && dt.Columns.Contains(colname))
            {
                id = (int)dt.Rows[0][colname];
            }
            DeleteSubTable(id, sproc, colname);
        }
        public static void DeleteSubTable(int id, string sproc, string colname)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(sproc);
            SQLUtility.SetParamValue(cmd, "@" + colname, id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static int Clone(int id)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("CloneRecipe");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);

            if (cmd.Parameters.Contains("@RecipeId"))
            {
                if (cmd.Parameters["@RecipeId"].Direction == ParameterDirection.InputOutput && cmd.Parameters["@RecipeId"].Value is int && cmd.Parameters["@RecipeId"].Value != null && (int)cmd.Parameters["@RecipeId"].Value > 0)
                {
                    id = (int)cmd.Parameters["@RecipeId"].Value;
                }
            }
            return id;
        }

        public static void AutoCreate(int id)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("CookbookAutoCreate");
            SQLUtility.SetParamValue(cmd, "@StaffId", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        // End of Class
    }
}