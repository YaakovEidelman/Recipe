--AS Keep to the same naming convention: RecipeUpdate
-- Completed
create or alter procedure RecipeUpdate
(
    @RecipeId int output,
    @StaffId int,
    @CuisineId int,
    @RecipeName varchar(25) output,
    @Calories int,
	@IsVegan bit = 0,
    @RecipeStatus varchar(9) = '' output,
    @DateDrafted date output,
    @DatePublished date output,
    @DateArchived date output
)
as 
begin

    select @RecipeId = isnull(@RecipeId, 0), @DateDrafted = isnull(@DateDrafted, cast(sysdatetimeoffset() at time zone 'Eastern Standard Time' as date)), @DatePublished = nullif(@DatePublished, ''), @DateArchived = nullif(@DateArchived, '')

    begin try
        if @RecipeId = 0
        begin 
            insert Recipe(StaffId, CuisineId, RecipeName, Calories, IsVegan, DateDrafted, DatePublished, DateArchived)
            values(@StaffId, @CuisineId, @RecipeName, @Calories, @IsVegan, @DateDrafted, @DatePublished, @DateArchived)

            select @RecipeId = scope_identity()
        end
        else 
        begin
            update r
            set 
                StaffId = @StaffId, 
                CuisineId = @CuisineId, 
                RecipeName = @RecipeName, 
                Calories = @Calories, 
				IsVegan = @IsVegan,
                DateDrafted = @DateDrafted, 
                DatePublished = @DatePublished, 
                DateArchived = @DateArchived
            from Recipe r
            where r.RecipeId = @RecipeId
        end
        select @RecipeStatus = (select r.RecipeStatus from Recipe r where r.RecipeId = @RecipeId)
    end try 
    begin catch
        throw
    end catch
end