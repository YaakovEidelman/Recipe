create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(100)
as
begin 
    declare @value varchar(100) = ''

    ;with x as (
        select r.RecipeId, recipedesc = concat(R.RecipeName, ' (', c.CuisineType, ') has ', count(ri.RecipeId), ' ingredients and ') 
        from Recipe r 
        join Cuisine c 
        on r.CuisineId = c.CuisineId
        left join RecipeIngredient ri 
        on r.RecipeId = ri.RecipeId
        where r.RecipeId = @RecipeId
        group by r.RecipeId, r.RecipeName, c.CuisineType
    )
    select @value = concat(x.recipedesc, count(rd.StepNum), ' steps')
    from x
    join Recipe r 
    on r.RecipeId = x.RecipeId
    left join RecipeDirection rd 
    on r.RecipeId = rd.RecipeId
    group by x.recipedesc

    return @value
end
go

select *, dbo.RecipeDesc(r.RecipeId)
from Recipe r