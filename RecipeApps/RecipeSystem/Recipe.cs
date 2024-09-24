using System.Data;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Recipe
    {
        // NOTE: THIS IS FROM THE PREVIOUS HOMEWORK FOR THE SEARCH FORM. SINCE THERE IS NO SEARCH FORM IN SESSION 26 PROJECT, I AM MAKING A NEW RECPE MIDDLE TIER BECAUSE I DON'T WANT
        // TO RUIN THE SEARCH FORM CODE. 
        // THE RECIPE CLASS I'M GOING TO USE WILL BE CALLED RECIPEPROJECT.cs
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
            SqlCommand cmd = SQLUtility.GetSqlCommand("StaffListGet");
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
            DataRow dr = dtrecipe.Rows[0];
            SQLUtility.SaveDataRow(dr, "RecipeUpsert");
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
