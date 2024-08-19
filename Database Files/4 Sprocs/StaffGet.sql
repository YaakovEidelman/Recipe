create or alter procedure StaffGet (@staffid int = 0, @username varchar(25) = '', @all bit = 0)
as 
begin 
	select @username = nullif(@username, '')
	select s.StaffId, s.FirstName, s.LastName, s.UserName
	from Staff s
	where s.StaffId = @staffid
	or @all = 1
	or s.UserName like '%' + @username + '%'
end
go

/*
exec StaffGet

exec StaffGet @all = 1

exec StaffGet @username = 'p'

declare @staffid int
select top 1 @staffid = s.staffid
from staff s
exec StaffGet @staffid = @staffid
*/