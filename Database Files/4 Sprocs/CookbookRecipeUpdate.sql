create or alter proc dbo.CookbookRecipeUpdate(
    @CookbookRecipeId int = 0 output,
    @CookbookId int,
    @RecipeId int,
    @RecipeSequence int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CookbookRecipeId = isnull(@CookbookRecipeId, 0)

    begin try
        if @CookbookRecipeId = 0
            begin
                insert CookBookRecipe(CookBookId, RecipeId, RecipeSequence)
                values(@CookbookId, @RecipeId, @RecipeSequence)

                select @CookbookRecipeId = scope_identity()
            end
        else
            begin
                update cr
                set cr.CookBookId = @CookbookId, 
                    cr.RecipeId = @RecipeId,
                    cr.RecipeSequence = @RecipeSequence
                from CookBookRecipe cr
                where cr.CookBookRecipeId = @CookbookRecipeId
            end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating or saving record.';
        throw
    end catch
    return @return
end
go