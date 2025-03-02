create or alter procedure dbo.MealGet
as 
begin 
    select m.MealId, m.MealName, 'User' = concat(s.FirstName, ' ', s.LastName), 'NumCalories' = sum(r.Calories), 'NumCourses' = count(distinct mc.CourseId), 'NumRecipes' = count(mcr.RecipeId), m.MealDesc
    from Meal m
    left join MealCourse mc
    on mc.MealId = m.MealId
    left join MealCourseRecipe mcr 
    on mc.MealCourseId = mcr.MealCourseId
    left join Recipe r 
    on r.RecipeId = mcr.RecipeId
    left join Staff s 
    on m.StaffId = s.StaffId
    group by m.MealId, m.MealName, s.FirstName, s.LastName, m.MealDesc
    order by m.MealName
end
go