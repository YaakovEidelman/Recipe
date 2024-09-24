create or alter proc IngredientGet(
    @InsertBlank bit = 0
)
as
begin 
    select i.IngredientId, i.IngredientName, o = 1
    from Ingredient i
    union select 0, ' ', 0
    where @InsertBlank = 1
    order by o, i.IngredientName
end
go