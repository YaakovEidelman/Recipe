create or alter proc MeasurementGet(
    @InsertBlank bit = 0
)
as
begin 
    select m.MeasurementId, m.MeasurementType, o = 1
    from Measurement m
    union select 0, ' ', 0
    where @InsertBlank = 1
    order by o, m.MeasurementType
end
go