import { useEffect, useState } from "react";
import { IRecipe } from "../Interfaces";
import { fetchRecipes } from "../DataUtil";
import RecipeCard from "./RecipeCard";
import { RecipeCount } from "./RecipeCount";
import { useParams } from "react-router-dom";


export default function RecipeContentPage() {
    const [recipes, setRecipes] = useState<IRecipe[]>([]);


    let { id } = useParams();

    useEffect(() => {
        (async () => {
            setRecipes(await fetchRecipes("recipe/cuisine/" + id))
        })();
    }, [id]);

    return (
        <>
            <div className="row">
                <RecipeCount recipes={recipes} />
                {recipes.map((r, i) => (
                    <RecipeCard key={i} recipe={r} />
                ))}
            </div>
        </>
    )
}
