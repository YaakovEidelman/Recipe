create or alter procedure dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @CuisineId = isnull(@CuisineId, 0)
    begin try
        delete Cuisine where CuisineId = @CuisineId
    end try
    begin catch
            select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch
end 
go