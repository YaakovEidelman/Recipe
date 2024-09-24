create or alter procedure dbo.CourseUpdate(
    @CourseId int output,
    @CourseType varchar(25),
    @CourseSequenceNum int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CourseId = isnull(@CourseId, 0), @CourseType = isnull(@CourseType, '')

    begin try
        if @CourseId = 0
        begin
            insert Course(CourseType, CourseSequenceNum)
            values(@CourseType, @CourseSequenceNum)

            select @CourseId = scope_identity()
        end
        else
        begin
            update c
            set
                c.CourseType = @CourseType,
                c.CourseSequenceNum = @CourseSequenceNum
            from Course c 
            where c.CourseId = @CourseId
        end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating records.';
        throw
    end catch
    return @return
end
go