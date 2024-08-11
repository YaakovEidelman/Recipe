create or alter procedure RecipeDelete (@recipeid int)
as
begin
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
end 
go