--AS Try combining with StaffGet
-- Completed
create or alter procedure StaffGet(
--AS Parameters should be Propercase
-- Completed
	@StaffId int = 0, 
	@Username varchar(25) = '', 
	@All bit = 0,
	@InsertBlank bit = 0,
	@IsDataMaint bit = 0
)
as 
begin 
	if @IsDataMaint = 0
	begin
		select @Username = nullif(@username, '')
		select s.StaffId, s.FirstName, s.LastName, UserName = concat(s.FirstName, ' ', s.LastName)
		from Staff s
		where s.StaffId = @Staffid
		or @All = 1
		or s.UserName like '%' + @Username + '%'
		union select '', '', '', ''
		where @InsertBlank = 1
		order by s.FirstName
	end
	else 
	begin 
		select s.StaffId, s.FirstName, s.LastName, s.UserName
		from Staff s
		order by s.FirstName, s.LastName
	end
end
go