import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import RecipeContentPage from "./components/RecipeContentPage";
import { MealsPage } from "./components/MealsPage";
import { CookbookPage } from "./components/CookbookPage";
import RecipeEditPage from "./components/RecipeEditPage";

const routes = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "/recipecontent/:id?",
                element: <RecipeContentPage />
            },
            {
                path: "/meals",
                element: <MealsPage />
            },
            {
                path: "/cookbooks",
                element: <CookbookPage />
            },
            {
                path: "/recipeeditpage",
                element: <RecipeEditPage />
            }
        ]
    }
]);

export default routes;