create or alter procedure dbo.CookbookRecipeGet(
    @CookbookId int = 0
)
as 
begin
    select @CookbookId = isnull(@CookbookId, 0)

    select cr.CookBookRecipeId, cr.CookBookId, cr.RecipeId, cr.RecipeSequence
    from CookBookRecipe cr 
    join Recipe r 
    on cr.RecipeId = r.RecipeId
    where cr.CookBookId = @CookbookId
    order by cr.RecipeSequence
end
go