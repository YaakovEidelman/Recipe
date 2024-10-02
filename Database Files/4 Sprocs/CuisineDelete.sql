create or alter procedure dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CuisineId = isnull(@CuisineId, 0)
    begin try
        begin tran

            declare @RecipeIds table (RecipeId int)

            insert @RecipeIds(RecipeId)
            select distinct RecipeId
            from Recipe 
            where CuisineId = @CuisineId

            delete RecipeIngredient where RecipeId in (select RecipeId from @RecipeIds)
            delete RecipeDirection where RecipeId in (select RecipeId from @RecipeIds)
            delete MealCourseRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete CookbookRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete Recipe where RecipeId in (select RecipeId from @RecipeIds)

            delete Cuisine where CuisineId = @CuisineId
        commit
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.'
        rollback;
        throw
    end catch
end 
go