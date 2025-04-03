import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import Navbar from "./components/Navbar";
import RecipeCard from "./components/RecipeCard";
import { useEffect, useState } from "react";
import { IRecipe } from "./Interfaces";
import { fetchRecipes } from "./DataUtil";
import { RecipeEdit } from "./components/RecipeEdit";
import { RecipeCount } from "./components/RecipeCount";

let initRecipe: IRecipe = {
    recipeId: 0,
    staffId: 0,
    cuisineId: 0,
    recipeName: "",
    recipeStatus: "",
    username: "",
    calories: 0,
    dateDrafted: new Date().toISOString().split("T")[0],
    datePublished: null,
    dateArchived: null,
    recipeImagePath: "",
    numIngredients: 0,
    isVegan: false,
    errorMessage: ""
}

function App() {
    const [recipes, setRecipes] = useState<IRecipe[]>([]);
    const [cuisineId, setCuisineId] = useState<number | null>(0);
    const [editPage, setEditPage] = useState(false);
    const [recipeForEdit, setRecipeForEdit] = useState<IRecipe>(initRecipe);
    const [RecipeChange, setRecipeChange] = useState(false);

    useEffect(() => {
        (async () => {
            setRecipes(await fetchRecipes("recipe/cuisine/" + cuisineId));
        })();
    }, [cuisineId, RecipeChange]);

    const handleUpdateRecipeForEdit = (recipe: IRecipe) => {
        setEditPage(false);
        setRecipeForEdit(recipe);
        setEditPage(true);
    }

    const handleCuisineClick = (num: number) => {
        setCuisineId(num);
    };

    const handleEditPage = (isVisible: boolean) => {
        setEditPage(isVisible);
    }

    const updateRecipeChange = () => {
        setRecipeChange(!RecipeChange);
    }

    return (
        <>
            <div className="container-fluid">
                <div className="row">
                    <div className="col-12">
                        <Navbar cuisineClick={handleCuisineClick} showRecipesClick={handleEditPage} />
                    </div>
                    <div className="row">
                        <div className="col-4">
                            <button
                                onClick={() => handleUpdateRecipeForEdit(initRecipe)}
                                className="btn btn-outline-success"
                            >New Recipe</button>
                        </div>
                    </div>
                    <div className="row">
                        {
                            (editPage)
                                ? <RecipeEdit recipe={recipeForEdit} updateRecipe={updateRecipeChange}/>
                                : (
                                    <>
                                        <RecipeCount recipes={recipes} />
                                        {recipes.map((r, i) => <RecipeCard handleRecipeForEdit={handleUpdateRecipeForEdit} recipe={r} key={i} />)}
                                    </>
                                )
                        }
                    </div>
                </div>
            </div>
        </>
    );
}

export default App;
