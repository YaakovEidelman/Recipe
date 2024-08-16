
declare @recipeid int = 0

exec RecipeUpsert
    @RecipeId = @recipeid output,
    @StaffId = 1,
    @CuisineId = 2,
    @RecipeName = 'blag',
    @Calories = 50,
    @DateDrafted = null,
    @DatePublished = null,
    @DateArchived = null

select @recipeid

select *
from Recipe r 
where r.RecipeId = @RecipeId