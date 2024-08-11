create or alter procedure RecipeDelete (@recipeid int)
as
begin
    begin try
        begin tran
            delete rd
            from Recipe r
            left join RecipeDirection rd 
            on rd.RecipeId = r.RecipeId
            where r.RecipeId = @recipeid

            delete ri
            from Recipe r 
            left join RecipeIngredient ri 
            on ri.RecipeId = r.RecipeId
            where r.RecipeId = @recipeid

            delete r
            from Recipe r 
            where r.RecipeId = @recipeid
        commit
    end try
    begin catch
        rollback;
        throw
    end catch
end 
go