create or alter procedure dbo.MeasurementDelete(
    @MeasurementId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0
    select @MeasurementId = isnull(@MeasurementId, 0)
    begin try
        begin tran
            declare @RecipeIds table (RecipeId int)

            insert @RecipeIds(RecipeId)
            select distinct RecipeId
            from RecipeIngredient 
            where MeasurementId = @MeasurementId

            delete RecipeIngredient where RecipeId in (select RecipeId from @RecipeIds)
            delete RecipeDirection where RecipeId in (select RecipeId from @RecipeIds)
            delete MealCourseRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete CookbookRecipe where RecipeId in (select RecipeId from @RecipeIds)
            delete Recipe where RecipeId in (select RecipeId from @RecipeIds)

            delete Measurement where MeasurementId = @MeasurementId
        commit
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.'
        rollback;
        throw
    end catch
end
go