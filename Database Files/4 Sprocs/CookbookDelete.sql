create or alter procedure dbo.CookbookDelete(
    @CookbookId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return bit = 0
    select @CookbookId = isnull(@CookbookId, 0)
    if not exists(select CookBookId from CookBook where CookBookId = @CookbookId)
    begin 
        select @return = 1, @Message = 'Record does not exist'
        goto finished
    end
    begin try
        begin tran
            delete CookBookRecipe where CookBookId = @CookbookId
            delete CookBook where CookBookId = @CookbookId
        commit
    end try
    begin catch
        rollback;
        select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch

    finished:
    return @return
end
go

-- declare @val int, @m varchar(50)
-- exec @val = CookbookDelete @Message = @m output
-- select @val, @m