create or alter procedure CuisineGet (
	@cuisineid int = 0, 
	@cuisinetype varchar(25) = '', 
	@all bit = 0,
	@InsertBlank bit = 0
)
as 
begin 
	select @cuisineid = isnull(@cuisineid, 0), @cuisinetype = nullif(@cuisinetype, ''), @all = isnull(@all, 0), @InsertBlank = isnull(@InsertBlank, 0)

	select c.cuisineid, c.cuisinetype, o = 1
	from cuisine c
	where c.CuisineId = @cuisineid
	or @all = 1
	or c.CuisineType like '%' + @cuisinetype + '%'
	union select '', '', 0
	where @InsertBlank = 1
	order by o, c.CuisineType
end
go