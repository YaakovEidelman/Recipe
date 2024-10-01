create or alter procedure dbo.MealGet
as 
begin 
--AS Add in left joins so that all meals show up even if they have no related records.
    select m.MealId, m.MealName, 'User' = concat(s.FirstName, ' ', s.LastName), 'Num Calories' = sum(r.Calories), 'Num Courses' = count(distinct mc.CourseId), 'Num Recipes' = count(mcr.RecipeId)
    from Meal m
    left join MealCourse mc
    on mc.MealId = m.MealId
    left join MealCourseRecipe mcr 
    on mc.MealCourseId = mcr.MealCourseId
    left join Recipe r 
    on r.RecipeId = mcr.RecipeId
    left join Staff s 
    on m.StaffId = s.StaffId
    group by m.MealId, m.MealName, s.FirstName, s.LastName
    order by m.MealName
end
go