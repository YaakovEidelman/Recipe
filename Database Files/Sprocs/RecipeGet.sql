create or alter procedure RecipeGet (@recipeid int = 0, @recipename varchar(25) = '', @all bit = 0)
as 
begin 
	select @recipename = nullif(@recipename, '')
	select r.RecipeId, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeImagePath
	from Recipe r
	where r.RecipeId = @recipeid
	or @all = 1
	or r.RecipeName like '%' + @recipename + '%'
end
go

/*
exec RecipeGet

exec RecipeGet @all = 1

exec RecipeGet @recipename = 'p'

declare @recipeid int
select top 1 @recipeid = r.recipeid 
from recipe r
exec RecipeGet @recipeid = @recipeid
*/