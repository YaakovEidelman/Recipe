create or alter proc dbo.CloneRecipe(
   @RecipeId int = 0 output
)
as
begin
    begin try
        begin tran
            insert Recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
            select 
                r.StaffId, 
                r.CuisineId, 
                RecipeName = r.RecipeName + ' - Clone', 
                r.Calories,
                DateDrafted = cast(sysdatetimeoffset() at time zone 'Eastern Standard Time' as datetime),
                DatePublished = null,
                DateArchived = null
            from Recipe r
            where r.RecipeId = @RecipeId

            declare @BaseRecipeId int = @RecipeId
            select @RecipeId = scope_identity()

            insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientOrderNum)
            select 
                @RecipeId,
                ri.IngredientId,
                ri.MeasurementId,
                ri.Amount,
                ri.IngredientOrderNum
            from RecipeIngredient ri
            where ri.RecipeId = @BaseRecipeId

            insert RecipeDirection(RecipeId, StepNum, DirectionText)
            select 
                @RecipeId,
                rd.StepNum,
                rd.DirectionText
            from RecipeDirection rd
            where rd.recipeId = @BaseRecipeId
        commit tran
    end try 
    begin catch
        rollback;
        throw
    end catch
end
go