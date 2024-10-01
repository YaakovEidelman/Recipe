create or alter proc IngredientGet(
    @InsertBlank bit = 0
)
as
begin 
    select i.IngredientId, i.IngredientName
    from Ingredient i
    union select 0, ' '
    where @InsertBlank = 1
    order by i.IngredientName
end
go