import { useLocation } from "react-router-dom"
import { ICuisine, IStaff } from "../Interfaces";
import { useEffect, useState } from "react";
import { FieldValues, useForm } from "react-hook-form";
import { deleteRecipe, fetchCuisine, fetchStaff, postRecipe } from "../DataUtil";



export default function RecipeEditPage() {
  const location = useLocation();

  const { recipe } = location.state;

  const { register, handleSubmit, reset } = useForm({ defaultValues: recipe });
  const [cuisines, setCuisines] = useState<ICuisine[]>([]);
  const [staff, setStaff] = useState<IStaff[]>([]);
  const [errormsg, setErrorMsg] = useState("");


  useEffect(() => {
    (async () => {
      setCuisines(await fetchCuisine());
      setStaff(await fetchStaff());
      reset(recipe)
    })();
  }, [recipe]);

  const submitForm = async (data: FieldValues) => {
    const r = await postRecipe(data);
    setErrorMsg(r.errorMessage);
    reset(r);
  }

  const handleDeleteRecipe = async () => {
    const r = await deleteRecipe(recipe.recipeId);
    r.dateDrafted = new Date().toISOString().split("T")[0];
    setErrorMsg(r.errorMessage);
    reset(r);
  }

  return (
    <>
      <div className="row">
        <div className="col-6 m-5">
          <h2 className="text-center mb-4" id="msg">{errormsg}</h2>
          <form id="frm" onSubmit={handleSubmit(submitForm)}>
            <div className="mb-3">
              <input className="form-control" id="recipeId" {...register("recipeId")} required hidden/>
            </div>
            <div className="mb-3">
              <label htmlFor="staffId" className="form-label">Username</label>
              <select className="form-select" {...register("staffId")} id="staffId">
                {staff.map((s, i) =>
                  <option value={s.staffId} key={i}>{s.userName}</option>
                )}
              </select>
            </div>
            <div className="mb-3">
              <label htmlFor="cuisineId" className="form-label">Cuisine</label>
              <select className="form-select" id="cuisineId" {...register("cuisineId")}>
                {cuisines.map((c, i) =>
                  <option key={i} value={c.cuisineId}>{c.cuisineType}</option>
                )}
              </select>
            </div>
            <div className="mb-3">
              <label htmlFor="recipeName" className="form-label">Recipe Name</label>
              <input type="text" className="form-control" id="recipeName" {...register('recipeName')} required />
            </div>
            <div className="mb-3">
              <label htmlFor="calories" className="form-label">Calories</label>
              <input type="number" className="form-control" id="calories" {...register('calories')} required />
            </div>
            <div className="mb-3 form-check">
              <input type="checkbox" className="form-check-input" id="isVegan" {...register('isVegan')} />
              <label className="form-check-label" htmlFor="isVegan">Is Vegan</label>
            </div>
            <div className="mb-3">
              <label htmlFor="dateDrafted" className="form-label">Date Drafted</label>
              <input type="text" {...register("dateDrafted")} id="dateDrafted" className="form-control" required />
            </div>
            <button type="submit" className="btn btn-primary" id="submit">Save</button>
            <button type="button" onClick={handleDeleteRecipe} className="btn btn-danger" id="del">Delete</button>
          </form>
        </div>
      </div>
    </>
  )
}
