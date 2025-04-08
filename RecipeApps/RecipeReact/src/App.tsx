import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import Navbar from "./components/Navbar";
import { Outlet, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { ICuisine, IRecipe } from "./Interfaces";
import { fetchCuisine } from "./DataUtil";
import { CuisineNavbar } from "./components/CuisineNavbar";

let recipe: IRecipe = {
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

    const [cuisines, setCuisines] = useState<ICuisine[]>([]);

    const nav = useNavigate();

    useEffect(() => {
        (async () => {
            setCuisines(await fetchCuisine());
        })();
    }, []);

    return (
        <>
            <div className="container-fluid">
                <Navbar />
                <div className="row">
                    {cuisines.map((c, i) =>
                        <CuisineNavbar key={i} cuisine={c}/>
                    )}
                </div>
                <div className="row">
                    <div className="col">
                        <button className="btn btn-outline-success mt-3" onClick={() => nav("/recipeeditpage", { state: { recipe } })}>New Recipe</button>
                    </div>
                </div>
                <hr />
                <Outlet />
            </div>
        </>
    );
}

export default App;
