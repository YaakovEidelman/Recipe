--AS Try combining this sproc with CookbookGet
create or alter proc dbo.CookbookListGet
as 
begin
    select c.CookBookId, 'Cookbook Name' = c.CookBookName, 'Author' = concat(s.FirstName, ' ', s.LastName), 'Num Recipes' = count(cr.RecipeId), c.Price
    from CookBook c 
    left join CookBookRecipe cr 
    on cr.CookBookId = c.CookBookId
    left join Staff s 
    on c.StaffId = s.StaffId
    group by c.CookBookId, c.CookBookName, s.FirstName, s.LastName, c.Price
    order by c.CookBookName
end 
go