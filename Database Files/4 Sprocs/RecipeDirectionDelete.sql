create or alter procedure dbo.RecipeDirectionDelete(
    @RecipeDirectionId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0
    select @RecipeDirectionId = isnull(@RecipeDirectionId, 0)
    begin try
        delete rd 
        from RecipeDirection rd 
        where rd.RecipeDirectionId = @RecipeDirectionId
    end try
    begin catch
        select @return = 1, @Message = 'There was an issue deleting record.';
        throw
    end catch
    finish:
    return @return
end
go