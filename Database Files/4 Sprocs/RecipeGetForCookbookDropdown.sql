--AS Try combining this with RecipeGet
create or alter proc dbo.RecipeGetForCookbookDropdown
as
begin
    select r.RecipeId, r.RecipeName
    from Recipe r
end
go