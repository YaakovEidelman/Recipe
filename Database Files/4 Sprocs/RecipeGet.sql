create or alter procedure RecipeGet (
	@RecipeId int = 0, 
	@RecipeName varchar(25) = '', 
	@All bit = 0,
	@IsRecipeGet INT = 0,
	@InsertBlank int = 1,
	@CookbookName varchar(50) = ''
)
as 
begin 


	if @IsRecipeGet = 0
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
			r.DateDrafted,
			r.DatePublished, 
			r.DateArchived, 
			r.RecipeImagePath, 
			NumIngredients = count(ri.RecipeIngredientId),
			r.IsVegan
		from Recipe r
		join Staff s 
		on r.StaffId = s.StaffId
		left join RecipeIngredient ri 
		on ri.RecipeId = r.RecipeId
		where r.RecipeId = @RecipeId
		or @All = 1
		or r.RecipeName like '%' + @RecipeName + '%'
		group by r.RecipeId, r.StaffId, r.CuisineId, r.RecipeName, r.RecipeStatus, s.FirstName, s.LastName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeImagePath, r.IsVegan
		union select 0, 0, 0, '', '', '', null, null, null, null, null, null, null
		where @RecipeId = 0 and @InsertBlank = 1
		order by r.RecipeStatus desc
	end
	else if @IsRecipeGet = 1
	begin 
		select r.RecipeId, r.RecipeName, r.RecipeStatus, UserName = concat(s.FirstName, ' ', s.LastName), r.Calories, NumIngredients = count(ri.RecipeIngredientId), r.IsVegan
		from Recipe r 
		join Staff s
		on s.StaffId = r.StaffId
		left join RecipeIngredient ri 
		on ri.RecipeId = r.RecipeId

		left join CookBookRecipe cbr
		on cbr.RecipeId = r.RecipeId
		left join CookBook c
		on cbr.CookBookId = c.CookBookId
		where @CookbookName = ''
		or LOWER(REPLACE(@CookbookName, '-', ' ')) = c.CookBookName

		group by r.RecipeId, r.RecipeName, r.RecipeStatus, s.FirstName, s.LastName, r.Calories, r.IsVegan
		order by r.RecipeStatus desc
	end
	else if @IsRecipeGet = 2
	begin
	    select r.RecipeId, r.RecipeName
    	from Recipe r
	end
end
go

select * from Recipe
--RecipeGet @RecipeName = 'a', @InsertBlank = 1
--exec RecipeGet @CookbookName = 'Family Favorites Cookbook', @IsRecipeGet = 1

--	declare @name varchar(50) = 'Treats for Two'
--	declare @cbname varchar(50) = '';
--	select @cbname = r.RecipeName
--	from CookBookRecipe cbr
--	join Recipe r 
--	on cbr.RecipeId = r.RecipeId
--	join CookBook cb 
--	on cbr.CookBookId = cb.CookBookId
--	where cb.CookBookName = @name

--	select @cbname

--	select * from CookBook