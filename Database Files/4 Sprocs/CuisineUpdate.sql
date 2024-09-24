create or alter procedure dbo.CuisineUpdate(
    @CuisineId int output,
    @CuisineType varchar(25),
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CuisineId = isnull(@CuisineId, 0), @CuisineType = isnull(@CuisineType, '')

    begin try
        if @CuisineId = 0
        begin
            insert Cuisine(CuisineType)
            values(@CuisineType)

            select @CuisineId = scope_identity()
        end
        else
        begin
            update c
            set
                c.CuisineType = @CuisineType
            from Cuisine c
            where c.CuisineId = @CuisineId
        end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating records.';
        throw
    end catch
    return @return
end
go