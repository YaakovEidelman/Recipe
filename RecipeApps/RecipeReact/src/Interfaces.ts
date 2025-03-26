export interface ICuisine {
    cuisineId: number;
    cuisineType: string;
}

export interface IRecipe {
    recipeId: number;
    staffId: number;
    cuisineId: number;
    recipeName: string;
    recipeStatus: string;
    username: string;
    calories: number;
    dateDrafted: string;
    datePublished: string | null;
    dateArchived: string | null;
    recipeImagePath: string;
    numIngredients: number;
    isVegan: boolean;
}