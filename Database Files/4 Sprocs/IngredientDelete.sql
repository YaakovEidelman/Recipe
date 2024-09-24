create or alter procedure dbo.IngredientDelete(
    @IngredientId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @IngredientId = isnull(@IngredientId, 0)
    begin try
        delete Ingredient where IngredientId = @IngredientId
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch
end
go