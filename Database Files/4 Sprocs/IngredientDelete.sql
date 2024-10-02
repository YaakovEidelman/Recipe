create or alter procedure dbo.IngredientDelete(
    @IngredientId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @IngredientId = isnull(@IngredientId, 0)
    begin try
        begin transaction
            declare @RecipeIds table (RecipeId int)

            insert @RecipeIds(RecipeId)
            select distinct RecipeId
            from RecipeIngredient
            where IngredientId = @IngredientId

            delete RecipeIngredient where RecipeId in (select RecipeId from @RecipeIds)
            delete RecipeDirection where RecipeId in (select RecipeId from @RecipeIds)
            delete MealCourseRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete CookbookRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete Recipe where RecipeId in (select RecipeId from @RecipeIds)

            delete Ingredient where IngredientId = @IngredientId
        commit
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.'
        rollback;
        throw
    end catch
end
go