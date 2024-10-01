create or alter procedure CuisineGet (
--AS Paramaters should be proper case
-- Completed
	@CuisineId int = 0, 
	@CuisineType varchar(25) = '', 
	@All bit = 0,
	@InsertBlank bit = 0
)
as 
begin 
	select @cuisineid = isnull(@cuisineid, 0), @cuisinetype = nullif(@cuisinetype, ''), @all = isnull(@all, 0), @InsertBlank = isnull(@InsertBlank, 0)
--AS No need for o column, if you order by cuisintype it will display the blank at the top. Same for other sprocs.
-- Completed
	select c.CuisineId, c.CuisineType
	from cuisine c
	where c.CuisineId = @cuisineid
	or @all = 1
	or c.CuisineType like '%' + @cuisinetype + '%'
	union select '', ''
	where @InsertBlank = 1
	order by c.CuisineType
end
go