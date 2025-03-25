namespace RecipeSystem
{
    public class bizCuisine : bizObject<bizCuisine>
    {
        public int CuisineId { get; set; }
        public string CuisineType { get; set; } = "";
    }
}
