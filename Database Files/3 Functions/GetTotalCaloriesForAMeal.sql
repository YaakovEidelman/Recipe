create or alter function dbo.GetTotalCaloriesForAMeal(@MealId int)
returns int
as 
begin
    declare @cal int = 0

    select @cal = sum(r.Calories) 
    from  MealCourse mc 
    join MealCourseRecipe mcr 
    on mc.MealCourseId = mcr.MealCourseId
    join Recipe r 
    on mcr.RecipeId = r.RecipeId
    where mc.MealId = @MealId
    group by mc.MealId

    return @cal
end
go

select m.MealName, dbo.GetTotalCaloriesForAMeal(m.MealId)
from Meal m