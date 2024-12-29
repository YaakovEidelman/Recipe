using System.Reflection;

namespace RecipeSystem
{
    public class bizIngredient : bizObject<bizIngredient>
    {
        public List<bizIngredient> Search(string ingredientnameval, bool includeblank = false, bool all = false)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "IngredientName", ingredientnameval);
            SQLUtility.SetParamValue(cmd, "InsertBlank", includeblank);
            SQLUtility.SetParamValue(cmd, "All", all);
            return GetListFromDataTable(SQLUtility.GetDataTable(cmd));
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = "";
        public string IngredientImagePath { get; set; } = "";
    }
}