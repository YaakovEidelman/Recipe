create or alter procedure RecipeIngredientGet(
    @RecipeId int
)
as 
begin
    select ri.RecipeIngredientId, r.RecipeId, i.IngredientId, m.MeasurementId, ri.Amount, ri.IngredientOrderNum
    from Recipe r 
    left join RecipeIngredient ri 
    on ri.RecipeId = r.RecipeId
    left join Ingredient i 
    on ri.IngredientId = i.IngredientId
    left join Measurement m 
    on m.MeasurementId = ri.MeasurementId
    where r.RecipeId = @RecipeId
    order by r.RecipeName, ri.IngredientOrderNum
end
go