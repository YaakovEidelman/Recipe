create or alter procedure dbo.StaffUpdate(
    @StaffId int = output,
    @FirstName varchar(25),
    @LastName varchar(25),
    @UserName varchar(25),
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @StaffId = isnull(@StaffId, 0), @FirstName = isnull(@FirstName, ''), @LastName = isnull(@LastName, ''), @UserName = isnull(@UserName, '')

    begin try
        if @StaffId = 0
        begin
            insert Staff(FirstName, LastName, UserName)
            values(@FirstName, @LastName, @UserName)

            select @StaffId = scope_identity()
        end
        else
        begin
            update s 
            set
                s.FirstName = @FirstName,
                s.LastName = @LastName, 
                s.UserName = @UserName
            from Staff s 
            where s.StaffId = @StaffId
        end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating records.';
        throw
    end catch
    return @return
end
go