create or alter procedure dbo.CourseDelete(
    @CourseId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0
    select @CourseId = isnull(@CourseId, 0)
    begin try
    delete Course where CourseId = @CourseId
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch
end
go