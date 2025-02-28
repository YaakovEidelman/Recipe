namespace RecipeSystem
{
    public class bizMeal : bizObject<bizMeal>
    {
        public int MealId { get; set; }
        public string MealName { get; set; } = "";
        public string User { get; set; } = "";
        public int NumCalories { get; set; }
        public int NumCourses { get; set; }
        public int NumRecipes { get; set; }
    }
}