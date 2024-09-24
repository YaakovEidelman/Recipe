create or alter proc dbo.CookbookSave(
    @CookbookId int = 0 output,
    @StaffId int,
    @CookbookName varchar(50),
    @Price decimal(5, 2),
    @IsActive bit,
    @DateCreated datetime output
)
as 
begin
    select @CookbookId = isnull(@CookbookId, 0), @IsActive = isnull(@IsActive, 0), @DateCreated = isnull(@DateCreated, cast(sysdatetimeoffset() at time zone 'Eastern Standard Time' as datetime))

    begin try
        if @CookbookId = 0
        begin
            Insert CookBook(StaffId, CookBookName, Price, IsActive, DateCreated)
            values(@StaffId, @CookbookName, @Price, @IsActive, @DateCreated)

            select @CookbookId = scope_identity()
        end
        else
        begin
            update c 
            set 
                c.StaffId = @StaffId,
                c.CookBookName = @CookbookName,
                c.Price = @Price, 
                c.IsActive = @IsActive
            from CookBook c 
            where c.CookBookId = @CookbookId
        end
    end try
    begin catch
        if not exists( select * from Staff where StaffId = @StaffId) 
        throw 50001, 'Cannot insert null StaffId', 1;
        throw
    end catch
end
go