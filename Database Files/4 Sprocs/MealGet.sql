create or alter procedure dbo.MealGet
as 
begin 
    select m.MealId, m.MealName, 'User' = concat(s.FirstName, ' ', s.LastName), 'Num Calories' = sum(r.Calories), 'Num Courses' = count(distinct mc.CourseId), 'Num Recipes' = count(mcr.RecipeId)
    from Meal m
    join MealCourse mc
    on mc.MealId = m.MealId
    join MealCourseRecipe mcr 
    on mc.MealCourseId = mcr.MealCourseId
    join Recipe r 
    on r.RecipeId = mcr.RecipeId
    join Staff s 
    on m.StaffId = s.StaffId
    group by m.MealId, m.MealName, s.FirstName, s.LastName
    order by m.MealName
end
go

exec MealGet