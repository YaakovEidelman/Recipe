create or alter procedure dbo.StaffDelete(
    @StaffId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @StaffId = isnull(@StaffId, 0)
    begin try
        begin tran
            delete rd 
            from RecipeDirection rd 
            join Recipe r 
            on rd.recipeId = r.RecipeId
            where r.StaffId = @StaffId

            delete ri
            from RecipeIngredient ri
            join Recipe r 
            on ri.RecipeId = r.RecipeId
            where r.StaffId = @StaffId

            delete mcr 
            from MealCourseRecipe mcr
            join MealCourse mc
            on mcr.MealCourseId = mc.MealCourseId
            join Meal m 
            on m.MealId = mc.MealId
            join Recipe r 
            on mcr.RecipeId = r.RecipeId
            where m.StaffId = @StaffId
            or r.StaffId = @StaffId

            delete mc 
            from Meal m 
            join MealCourse mc
            on mc.MealId = m.MealId
            where m.StaffId = @StaffId

            delete Meal where StaffId = @StaffId

            delete cr 
            from CookBookRecipe cr 
            join CookBook c 
            on cr.CookBookId = c.CookBookId
            join Recipe r 
            on cr.RecipeId = r.RecipeId
            where c.StaffId = @StaffId
            or r.StaffId = @StaffId

            delete CookBook where StaffId = @StaffId

            delete Recipe where StaffId = @StaffId
            delete Staff where StaffId = @StaffId
        commit
    end try
    begin catch
        rollback
        select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch
end
go