create or alter function dbo.GetTotalCaloriesForAMeal(@MealId int)
returns int
as 
begin
    declare @cal int = 0

    select @cal = sum(r.Calories) 
    from Meal m 
    join MealCourse mc 
    on m.MealId = mc.MealId
    join MealCourseRecipe mcr 
    on mc.MealCourseId = mcr.MealCourseId
    join Recipe r 
    on mcr.RecipeId = r.RecipeId
    where m.MealId = @MealId
    group by m.MealId

    return @cal
end
go

select m.MealName, dbo.GetTotalCaloriesForAMeal(m.MealId)
from Meal m