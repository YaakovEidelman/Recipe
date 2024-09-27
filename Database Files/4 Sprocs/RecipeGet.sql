create or alter procedure RecipeGet (
	@RecipeId int = 0, 
	@RecipeName varchar(25) = '', 
	@All bit = 0
)
as 
begin 
	select @RecipeName = nullif(@RecipeName, '')
	select 
		r.RecipeId, 
		r.StaffId, 
		r.CuisineId, 
		r.RecipeName, 
		r.RecipeStatus, 
		Username = concat(s.FirstName, ' ', s.LastName),  
		r.Calories, 
		-- DateDrafted = cast(r.DateDrafted as date),
		-- DatePublished = cast(r.DatePublished as date), 
		-- DateArchived = cast(r.DateArchived as date), 
		r.DateDrafted,
		r.DatePublished, 
		r.DateArchived, 
		r.RecipeImagePath, 
		NumIngredients = count(ri.RecipeIngredientId)
	from Recipe r
	join Staff s 
	on r.StaffId = s.StaffId
	left join RecipeIngredient ri 
    on ri.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
	group by r.RecipeId, r.StaffId, r.CuisineId, r.RecipeName, r.RecipeStatus, s.FirstName, s.LastName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeImagePath
	union select 0, 0, 0, '', '', '', null, null, null, null, null, null
	where @RecipeId = 0
	order by r.RecipeStatus desc
end
go