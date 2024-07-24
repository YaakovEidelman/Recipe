using System.Data;
using System.Diagnostics;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable GetRecipeSearchResults(string recipename)
        {
            string sql = "select r.recipeid, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived from Recipe r where r.RecipeName like '%" + recipename + "%'";
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetSpecificRecipe(int id)
        {
            string sql = "select r.recipeid, r.StaffId, r.CuisineId, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived from Recipe r where r.recipeid = " + id;
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetStaffTable()
        {
            return SQLUtility.GetDataTable("select s.StaffId, s.username from Staff s");
        }

        public static DataTable GetCuisineTable()
        {
            return SQLUtility.GetDataTable("select c.CuisineId, c.CuisineType from Cuisine c");
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
            string sql = "delete recipe where recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
        }

        //End of class
    }
}
