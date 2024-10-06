create or alter proc RecipeIngredientUpdate(
    @RecipeIngredientId int = 0 output,
    @RecipeId int,
    @IngredientId int,
    @MeasurementId int,
    @Amount decimal(4, 2),
    @IngredientOrderNum int
)
as 
begin
    select @RecipeIngredientId = isnull(@RecipeIngredientId, 0), @MeasurementId = nullif(@MeasurementId, 0)

    begin try
        if @RecipeIngredientId = 0
        begin
            insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientOrderNum)
            values(@RecipeId, @IngredientId, @MeasurementId, @Amount, @IngredientOrderNum)

            select @RecipeIngredientId = scope_identity()
        end
        else
        begin 
            update ri 
            set 
                ri.RecipeId = @RecipeId,
                ri.IngredientId = @IngredientId,
                ri.MeasurementId = @MeasurementId,
                ri.Amount = @Amount,
                ri.IngredientOrderNum = @IngredientOrderNum
            from RecipeIngredient ri
            where ri.RecipeIngredientId = @RecipeIngredientId
        end
    end try
    begin catch
        throw
    end catch
end