create or alter proc dbo.CourseGet
as
begin
    select c.CourseId, c.CourseType, c.CourseSequenceNum
    from Course c 
    order by c.CourseSequenceNum
end 
go

exec CourseGet