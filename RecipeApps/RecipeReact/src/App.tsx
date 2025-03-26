import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import Navbar from "./components/Navbar";
import RecipeCard from "./components/RecipeCard";
import { useEffect, useState } from "react";
import { IRecipe } from "./Interfaces";

function App() {
    const [recipes, setRecipes] = useState<IRecipe[]>([]);
    const [cuisineId, setCuisineId] = useState<number | null>(0);

    useEffect(() => {
        const fetchData = async () => {
            const r = await fetch(
                "https://recipeapiye.azurewebsites.net/api/recipe/cuisine/" +
                    cuisineId
            );
            const data = await r.json();
            setRecipes(data);
        };
        fetchData();
    }, [recipes]);

    const handleCuisineClick = (num: number) => {
        setCuisineId(num);
    };

    return (
        <>
            <div className="container-fluid">
                <div className="row">
                    <div className="col-12">
                        <Navbar cuisineClick={handleCuisineClick}/>
                    </div>
                    <div className="row">
                        <h3>{recipes.length === 0? "Select a cuisine from the recipe drop downlist" : `${recipes.length} recipes`}</h3>
                        {recipes.length > 0 && (
                            recipes.map((r, i) => (
                                <RecipeCard recipe={r} key={i}/>
                            ))
                        )}
                    </div>
                </div>
            </div>
        </>
    );
}

export default App;
