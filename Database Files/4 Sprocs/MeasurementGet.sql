create or alter proc MeasurementGet(
    @InsertBlank bit = 0
)
as
begin 
    select m.MeasurementId, m.MeasurementType
    from Measurement m
    union select 0, ' '
    where @InsertBlank = 1
    order by m.MeasurementType
end
go