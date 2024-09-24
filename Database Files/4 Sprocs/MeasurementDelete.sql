create or alter procedure dbo.MeasurementDelete(
    @MeasurementId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0
    select @MeasurementId = isnull(@MeasurementId, 0)
    begin try
        delete Measurement where MeasurementId = @MeasurementId
    end try
    begin catch
        select @return = 1, @Message = 'There was an error deleting record.';
        throw
    end catch
end
go