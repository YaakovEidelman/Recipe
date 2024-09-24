create or alter procedure dbo.RecipeIngredientDelete(
    @RecipeIngredientId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @RecipeIngredientId = isnull(@RecipeIngredientId, 0)
    begin try
        delete RecipeIngredient where RecipeIngredientId = @RecipeIngredientId
    end try
    begin catch
        select @return = 1, @Message = 'There was an issue deleting record.';
        throw
    end catch
end
go