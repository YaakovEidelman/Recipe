namespace RecipeSystem
{
    public class bizRecipe : bizObject<bizRecipe>
    {
        public bizRecipe()
        {

        }

        public List<bizRecipe> Search(string recipenameval, bool includeblank = false)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipenameval);
            SQLUtility.SetParamValue(cmd, "@InsertBlank", includeblank);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int RecipeId { get; set; }
        public int StaffId { get; set; }
        public int CuisineId { get; set; }
        public string RecipeName { get; set; } = "";
        public int Calories { get; set; }
        public string RecipeStatus { get; set; } = "";
        public DateTime DateDrafted { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateArchived { get; set; }
        public string RecipeImagePath { get; set; } = "";
    }
}