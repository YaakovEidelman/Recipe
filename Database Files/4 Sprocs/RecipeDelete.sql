create or alter procedure RecipeDelete (
    @RecipeId int, 
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @RecipeId = isnull(@RecipeId, 0)
    if not exists (select * from Recipe where RecipeId = @RecipeId)
    begin
        select @return = 1, @Message = 'This record doesn''t exist.'
        goto finish
    end
    if exists(select * from Recipe r where r.RecipeId = @recipeid and (r.RecipeStatus = 'Published' or datediff(day, r.DateArchived, current_timestamp) < 30))
    begin
        select @return = 1, @message = 'Cannot delete: Recipe is either published or not archived for 30 days.'
        goto finish
    end
    begin try
        begin tran
            delete RecipeDirection where RecipeId = @recipeid
            delete RecipeIngredient where RecipeId = @recipeid
            delete Recipe where RecipeId = @recipeid
        commit
    end try
    begin catch
        rollback
        select @return = 1, @Message = 'There was an error deleting records.';
        throw
    end catch

    finish:
    return @return
end 
go