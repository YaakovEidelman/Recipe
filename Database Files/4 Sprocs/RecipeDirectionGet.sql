create or alter proc RecipeDirectionGet(
    @RecipeId int = 0
)
as
begin 
    select @RecipeId = isnull(@RecipeId, 0)
    select rd.RecipeDirectionId, rd.RecipeId, rd.StepNum, rd.DirectionText
    from RecipeDirection rd
    where rd.RecipeId = @RecipeId
end
go