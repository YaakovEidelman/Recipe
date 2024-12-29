create or alter proc IngredientGet(
    @IngredientName varchar(100) = '',
    @All bit = 1,
    @InsertBlank bit = 0
)
as
begin 
    select i.IngredientId, i.IngredientName
    from Ingredient i
    where i.IngredientName like '%' + @IngredientName + '%'
    or @All = 1
    union select 0, ' '
    where @InsertBlank = 1
    order by i.IngredientName
end
go

exec IngredientGet
exec IngredientGet @IngredientName = 'a', @All = 0
select * from Ingredient where IngredientName like '%a%'