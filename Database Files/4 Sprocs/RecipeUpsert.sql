create or alter procedure RecipeUpsert 
(
    @RecipeId int output,
    @StaffId int,
    @CuisineId int,
    @RecipeName varchar(25),
    @Calories int,
    @DateDrafted datetime,
    @DatePublished datetime,
    @DateArchived datetime
)
as 
begin

    select @RecipeId = isnull(@RecipeId, 0), @DateDrafted = isnull(@DateDrafted, current_timestamp), @DatePublished = isnull(@DatePublished, 0), @DateArchived = isnull(@DateArchived, 0)

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
end