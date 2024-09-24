create or alter procedure dbo.MeasurementUpdate(
    @MeasurementId int output,
    @MeasurementType varchar(20),
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
    select @MeasurementId = isnull(@MeasurementId, 0), @MeasurementType = isnull(@MeasurementType, '')

    begin try
        if @MeasurementId = 0
        begin
            insert Measurement(MeasurementType)
            values(@MeasurementType)

            select @MeasurementId = scope_identity()
        end
        else
        begin
            update m
            set
                m.MeasurementType = @MeasurementType
            from Measurement m
            where m.MeasurementId = @MeasurementId
        end
    end try
    begin catch
        select @return = 1, @Message = 'There was an error updating records.';
        throw
    end catch
    return @return
end
go