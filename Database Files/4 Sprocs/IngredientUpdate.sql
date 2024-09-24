create or alter procedure dbo.IngredientUpdate(
    @IngredientId int output,
    @IngredientName varchar(50),
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @IngredientId = isnull(@IngredientId, 0), @IngredientName = isnull(@IngredientName, '')

    begin try
        if @IngredientId = 0
        begin
            insert Ingredient(IngredientName)
            values(@IngredientName)

            select @IngredientId = scope_identity()
        end
        else
        begin
            update i
            set
                i.IngredientName = @IngredientName
            from Ingredient i
            where i.IngredientId = @IngredientId
        end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating records.';
        throw
    end catch
    return @return
end
go