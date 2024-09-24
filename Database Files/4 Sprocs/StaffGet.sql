create or alter procedure dbo.StaffGet
as
begin
    select s.StaffId, s.FirstName, s.LastName, s.UserName
    from Staff s
    order by s.FirstName, s.LastName
end
go