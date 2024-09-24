create or alter procedure dbo.CookbookGet(
    @CookbookId int = 0
)
as 
begin 
    select @CookbookId = isnull(@CookbookId, 0)

    select c.CookBookId, c.StaffId, c.CookBookName, c.Price, c.IsActive, c.DateCreated
    from CookBook c
    where c.CookBookId = @CookbookId
    union select 0, 0, '', 0, 0, null
    where @CookbookId = 0
end
go