import { IRecipe } from "../Interfaces";

interface Props {
    recipe: IRecipe
}

function RecipeCard({recipe}: Props) {
    return (
        <>
            <div className="col-lg-6">
                <div className="card">
                    <img
                        className="card-img-top"
                        src={`/images/${recipe.recipeName.toLowerCase()}.jpg`}
                        alt="Card image cap"
                        style={{width: "100%", height: "auto"}}
                    />
                    <div className="card-body">
                        <h5 className="card-title">{recipe.recipeName}</h5>
                    </div>
                </div>
            </div>
        </>
    );
}

export default RecipeCard;
