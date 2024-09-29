create or alter procedure dbo.CookbookAutoCreate(
    @CookbookId int = 0 output,
    @StaffId int = 0
)
as
begin 
    begin try
        begin tran
            insert CookBook(StaffId, CookBookName, Price, IsActive, DateCreated)
            select s.StaffId, concat('Recipes by ', s.FirstName, ' ', s.LastName), count(r.RecipeId) * 1.33, 1, cast(sysdatetimeoffset() at time zone 'Eastern Standard Time' as datetime)
            from Recipe r 
            join Staff s 
            on r.StaffId = s.StaffId
            where r.StaffId = @StaffId
            group by s.StaffId, s.FirstName, s.LastName

            select @CookbookId = scope_identity()

            insert CookBookRecipe(CookBookId, RecipeId, RecipeSequence)
            select @CookbookId, r.RecipeId, row_number() over (order by r.RecipeName)
            from Recipe r 
            where r.StaffId = @StaffId
            order by r.RecipeName
        commit
    end try 
    begin catch
        rollback;
        throw
    end catch
end
go