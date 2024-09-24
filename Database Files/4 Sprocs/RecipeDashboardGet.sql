create or alter procedure dbo.RecipeDashboardGet
as 
begin
    select 'Recipes' as 'Type', 'Number' = count(r.RecipeId)
    from Recipe r 
    union select 'Meals', count(m.MealId)
    from Meal m
    union select 'Cookbooks', count(c.CookbookId)
    from CookBook c
    order by 'Type' desc
end
go