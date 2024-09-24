create or alter proc dbo.CookbookRecipeDelete(
    @CookbookRecipeId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0
    select @CookbookRecipeId = isnull(@CookbookRecipeId, 0)

    begin try
        delete CookBookRecipe where CookBookRecipeId = @CookbookRecipeId
    end try
    begin catch
        select @return = 1, @Message = 'There was an issue deleting record.';
        throw
    end catch
end 
go