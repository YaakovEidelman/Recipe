create or alter procedure RecipeDirectionSave(
    @RecipeDirectionId int = 0 output,
    @RecipeId int,
    @StepNum int,
    @DirectionText varchar(5000) = ''
)
as
begin 
    select @RecipeDirectionId = isnull(@RecipeDirectionId, 0)

    begin try
        if @RecipeDirectionId = 0
        begin
            insert RecipeDirection(RecipeId, StepNum, DirectionText)
            values(@RecipeId, @StepNum, @DirectionText)

            select @RecipeDirectionId = scope_identity()
        end
        else
        begin
            update rd
            set 
                rd.RecipeId = @RecipeId,
                rd.StepNum = @StepNum,
                rd.DirectionText = @DirectionText
            from RecipeDirection rd 
            where rd.RecipeDirectionId = @RecipeDirectionId
        end
    end try 
    begin catch
    throw
    end catch
end
go