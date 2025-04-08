import { IRecipe } from "../Interfaces"

interface Props {
    recipes: IRecipe[];
}

export function RecipeCount({ recipes }: Props) {

    return (
        <>
            <div className="row">
                <div className="col-12">
                    <h3>
                        {recipes.length === 0
                            ? "Choose a Cuisine"
                            : recipes.length === 1
                                ? `1 Recipe`
                                : `${recipes.length} Recipes`
                        }
                    </h3>
                </div>
            </div>
        </>
    )
}