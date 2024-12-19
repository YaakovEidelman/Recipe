namespace RecipeSystem
{
    public class bizRecipe : bizObject
    {
        public bizRecipe()
        {
            
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

