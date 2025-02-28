create or alter procedure dbo.CookbookGet(
    @CookbookId int = 0,
    @All bit
)
as 
begin 
    select @CookbookId = isnull(@CookbookId, 0)

    if @All = 0
    begin
        select c.CookBookId, c.StaffId, c.CookBookName, c.Price, c.IsActive, c.DateCreated
        from CookBook c
        where c.CookBookId = @CookbookId
        union select 0, 0, '', 0, 0, null
        where @CookbookId = 0
    end
    else 
    begin 
        select c.CookBookId, 'CookBookName' = c.CookBookName, 'Author' = concat(s.FirstName, ' ', s.LastName), 'NumRecipes' = count(cr.RecipeId), c.Price
        from CookBook c 
        left join CookBookRecipe cr 
        on cr.CookBookId = c.CookBookId
        left join Staff s 
        on c.StaffId = s.StaffId
        group by c.CookBookId, c.CookBookName, s.FirstName, s.LastName, c.Price
        order by c.CookBookName
    end
end
go

exec CookbookGet @All = 0, @CookbookId = 2
exec CookbookGet @All = 1