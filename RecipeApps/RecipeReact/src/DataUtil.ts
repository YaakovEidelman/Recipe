import { FieldValues } from "react-hook-form";
import { ICuisine, IRecipe, IStaff } from "./Interfaces";

let baseurl = "https://recipeapiye.azurewebsites.net/api/";
//baseurl = "https://localhost:7089/api/";

async function fetchData<T>(url: string): Promise<T> {
    let response = await fetch(baseurl + url);
    return await response.json();
}

async function postData<T>(url: string, form: FieldValues): Promise<T> {
    let r = await fetch(baseurl + url, {
        method: "POST",
        body: JSON.stringify(form),
        headers: {
            "Content-Type": "application/json"
        }
    });
    return await r.json();
}

async function deleteData<T>(url: string): Promise<T> {
    let r = await fetch(baseurl + url, {
        method: "DELETE"
    });
    return await r.json();
}

export async function fetchRecipes(url: string): Promise<IRecipe[]> {
    return await fetchData<IRecipe[]>(url);
}

export async function fetchCuisine(): Promise<ICuisine[]> {
    return await fetchData<ICuisine[]>("cuisine");
}

export async function fetchStaff() {
    return await fetchData<IStaff[]>("staff");
}

export async function postRecipe(form: FieldValues) {
    return await postData<IRecipe>('recipe/upsert', form);
}

export async function deleteRecipe(id: number) {
    return await deleteData<IRecipe>("recipe/delete?recipeid=" + id);
}