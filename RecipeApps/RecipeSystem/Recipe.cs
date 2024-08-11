using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable GetRecipeSearchResults(string recipename)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
            cmd.Parameters["@recipename"].Value = recipename;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetSpecificRecipe(int id)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
            cmd.Parameters["@recipeid"].Value = id;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetStaffTable()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("StaffGet");
            cmd.Parameters["@all"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineTable()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("CuisineGet");
            cmd.Parameters["@all"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtrecipe, bool isdatedraftedblank)
        {
            string sql;
            DataRow dr = dtrecipe.Rows[0];
            int id = (int)dr["recipeid"];
            string published = string.IsNullOrEmpty(dr["DatePublished"].ToString()) ? "null" : $"'{dr["DatePublished"]}'";
            string archived = string.IsNullOrEmpty(dr["DateArchived"].ToString()) ? "null" : $"'{dr["DateArchived"]}'";

            if (id > 0)
            {
                sql = string.Join(
                    Environment.NewLine,
                    $"update r set ",
                    $"r.RecipeName = '{dr["RecipeName"]}',",
                    $"r.Calories = {dr["Calories"]},",
                    $"r.DateDrafted = '{dr["DateDrafted"]}',",
                    $"r.DatePublished = {published},",
                    $"r.DateArchived = {archived}",
                    $"from recipe r where r.recipeid = {dr["recipeid"]}"
                );
            }
            else
            {
                if (isdatedraftedblank)
                {
                    sql = "insert recipe(StaffId, CuisineId, RecipeName, Calories, DatePublished, DateArchived)";
                    sql += $"select '{dr["StaffId"]}', '{dr["CuisineId"]}', '{dr["RecipeName"]}', {dr["Calories"]}, {published}, {archived}";
                }
                else
                {
                    sql = "insert recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)";
                    sql += $"select '{dr["StaffId"]}', '{dr["CuisineId"]}', '{dr["RecipeName"]}', {dr["Calories"]}, '{dr["DateDrafted"]}', {published}, {archived}";
                }
            }

            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }
        public static void Delete(DataTable dtrecipe)
        {
            DataRow dr = dtrecipe.Rows[0];
            int id = (int)dr["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDelete");
            cmd.Parameters["@recipeid"].Value = id;
            SQLUtility.ExecuteSQL(cmd);
        }

        //End of class
    }
}
