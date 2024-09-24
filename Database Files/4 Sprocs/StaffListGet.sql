create or alter procedure StaffListGet(
	@staffid int = 0, 
	@username varchar(25) = '', 
	@all bit = 0,
	@InsertBlank bit = 0
)
as 
begin 
	select @username = nullif(@username, '')
	select s.StaffId, s.FirstName, s.LastName, UserName = concat(s.FirstName, ' ', s.LastName), o = 1
	from Staff s
	where s.StaffId = @staffid
	or @all = 1
	or s.UserName like '%' + @username + '%'
	union select '', '', '', '', 0
	where @InsertBlank = 1
	order by o
end
go