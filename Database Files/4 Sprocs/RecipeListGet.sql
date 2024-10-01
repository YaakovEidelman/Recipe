--AS Try combining with RecipeGet sproc
create or alter proc dbo.RecipeListGet
as 
begin
    select r.RecipeId, r.RecipeName, r.RecipeStatus, UserName = concat(s.FirstName, ' ', s.LastName), r.Calories, NumIngredients = count(ri.RecipeIngredientId)
    from Recipe r 
    join Staff s
    on s.StaffId = r.StaffId
    left join RecipeIngredient ri 
    on ri.RecipeId = r.RecipeId
    group by r.RecipeId, r.RecipeName, r.RecipeStatus, s.FirstName, s.LastName, r.Calories
    order by r.RecipeStatus desc
end
go

exec RecipeListGet