import { IRecipe } from "../Interfaces"

interface Props {
    recipes: IRecipe[];
}

export function RecipeCount({ recipes }: Props) {

    return (
        <>
            <div className="row">
                <div className="col-12">
                    <h3>{recipes.length === 0 ? "Select a cuisine from the recipe drop downlist" : `${recipes.length} recipes`}</h3>
                </div>
            </div>
        </>
    )
}