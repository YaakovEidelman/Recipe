create or alter procedure RecipeDelete (
    @recipeid int, 
    @message varchar(500) = '' output
)
as
begin
    declare @return int = 0
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
        rollback;
        throw
    end catch

    finish:
    return @return
end 
go