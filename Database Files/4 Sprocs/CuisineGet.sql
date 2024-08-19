create or alter procedure CuisineGet (@cuisineid int = 0, @cuisinetype varchar(25) = '', @all bit = 0)
as 
begin 
	select @cuisinetype = nullif(@cuisinetype, '')
	select c.cuisineid, c.cuisinetype
	from cuisine c
	where c.CuisineId = @cuisineid
	or @all = 1
	or c.CuisineType like '%' + @cuisinetype + '%'
end
go

/*
exec CuisineGet

exec CuisineGet @all = 1

exec CuisineGet @cuisinetype = 'a'

declare @cuisineid int
select top 1 @cuisineid = c.cuisineid 
from cuisine c
exec CuisineGet @cuisineid = @cuisineid
*/