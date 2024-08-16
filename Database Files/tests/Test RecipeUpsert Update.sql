declare @RecipeId int, @StaffId int, @CuisineId int, @RecipeName varchar(50), @Calories int, @DateDrafted datetime, @datepublished datetime, @DateArchived datetime

select top 1 
    @RecipeId = r.recipeid, 
    @StaffId = r.StaffId, 
    @CuisineId = r.CuisineId, 
    @RecipeName = reverse(r.RecipeName), 
    @Calories = r.Calories,
    @Datedrafted = r.DateDrafted, 
    @datepublished = r.DatePublished, 
    @DateArchived = r.DateArchived
from Recipe r

select * from Recipe r where r.RecipeId = @RecipeId

exec RecipeUpsert
    @RecipeId = @RecipeId,
    @StaffId = @StaffId,
    @CuisineId = @CuisineId,
    @RecipeName = @RecipeName,
    @Calories = 109,
    @DateDrafted = @Datedrafted,
    @DatePublished = null,
    @DateArchived = @DateArchived

select *
from Recipe r 
where r.RecipeId = @RecipeId