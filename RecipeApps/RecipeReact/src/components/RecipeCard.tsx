import { useNavigate } from "react-router-dom";
import { IRecipe } from "../Interfaces";

interface Props {
    recipe: IRecipe;
}

function RecipeCard({ recipe }: Props) {
    const torecipeedit = useNavigate();
    return (
        <>
            <div className="col-lg-4">
                <div className="card">
                    <img className="card-img-top" src={`/images/${recipe.recipeName.toLowerCase()}.jpg`} alt="Card image cap"
                        style={{ width: "100%", maxHeight: "40vh" }} />
                    <div className="card-body">
                        <h5 className="card-title">{recipe.recipeName}</h5>
                    </div>
                    <div className="row p-1">
                        <div className="col">
                            <button
                                onClick={() => torecipeedit("/recipeeditpage", { state: { recipe } })}
                                className="btn btn-outline-primary w-100"
                            >Edit</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default RecipeCard;
