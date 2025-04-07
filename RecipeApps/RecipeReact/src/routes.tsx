import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import RecipeContentPage from "./components/RecipeContentPage";
import { MealsPage } from "./components/MealsPage";
import { CookbookPage } from "./components/CookbookPage";

const routes = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "/recipecontent",
                element: <RecipeContentPage />
            },
            {
                path: "/meals",
                element: <MealsPage />
            },
            {
                path: "/cookbooks",
                element: <CookbookPage />
            }
        ]
    }
]);

export default routes;