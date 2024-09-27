create or alter procedure RecipeUpsert 
(
    @RecipeId int output,
    @StaffId int,
    @CuisineId int,
    @RecipeName varchar(25) output,
    @Calories int,
    @RecipeStatus varchar(9) = '' output,
    @DateDrafted datetime output,
    @DatePublished datetime output,
    @DateArchived datetime output
)
as 
begin

    select @RecipeId = isnull(@RecipeId, 0), @DateDrafted = isnull(@DateDrafted, cast(sysdatetimeoffset() at time zone 'Eastern Standard Time' as datetime)), @DatePublished = nullif(@DatePublished, ''), @DateArchived = nullif(@DateArchived, '')

    begin try
        if @RecipeId = 0
        begin 
            insert Recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
            values(@StaffId, @CuisineId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived)

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
