namespace RecipeSystem
{
    public class bizRecipe : bizObject<bizRecipe>
    {
        public bizRecipe()
        {

        }

        public List<bizRecipe> Search(int recipeid, string recipenameval, bool includeblank = false)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipenameval);
            SQLUtility.SetParamValue(cmd, "@InsertBlank", includeblank);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }


        public int RecipeId { get; set; }
        public int StaffId { get; set; }
        public int CuisineId { get; set; }
        public string RecipeName { get; set; } = "";
        public string RecipeStatus { get; set; } = "";
        public string Username { get; set; } = "";
        public int Calories { get; set; }
        public DateTime DateDrafted { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateArchived { get; set; }
        public string RecipeImagePath { get; set; } = "";
        public int NumIngredients { get; set; }
        public bool IsVegan { get; set; }
    }
}