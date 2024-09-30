create or alter procedure dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CuisineId = isnull(@CuisineId, 0)
    begin try
        begin tran
        
            -- delete mcr 
            -- from MealCourseRecipe mcr 
            -- join Recipe r 
            -- on mcr.RecipeId = r.RecipeId
            -- where r.CuisineId = @CuisineId

            -- delete cr 
            -- from CookBookRecipe cr 
            -- join Recipe r 
            -- on cr.RecipeId = r.RecipeId
            -- where r.CuisineId = @CuisineId

            -- delete ri 
            -- from RecipeIngredient ri 
            -- join Recipe r 
            -- on ri.RecipeId = r.RecipeId
            -- where r.CuisineId = @CuisineId

            -- delete rd 
            -- from RecipeDirection rd 
            -- join Recipe r 
            -- on r.RecipeId = rd.RecipeId
            -- where r.CuisineId = @CuisineId
            
            -- delete Recipe where CuisineId = @CuisineId

            delete Cuisine where CuisineId = @CuisineId
        commit
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.'
        rollback;
        throw
    end catch
end 
go