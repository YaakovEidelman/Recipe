--AS Try combining this with RecipeGet
create or alter proc dbo.RecipeGetForCookbookDropdown
as
begin
    select r.RecipeId, r.RecipeName, o = 1
    from Recipe r
    union select 0, ' ', 0
    order by o
end
go