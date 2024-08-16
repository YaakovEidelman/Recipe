select * 
from recipe r 
where r.RecipeStatus = 'Draft'
or (r.RecipeStatus = 'Archived' and datediff(day, r.DateArchived, current_timestamp) >= 30)

select * 
from Recipe r 
where r.RecipeStatus = 'Published'
or datediff(day, r.DateArchived, current_timestamp) < 30

declare @return int, @message varchar(500)
exec @return = RecipeDelete @recipeid = 10, @message = @message output
select @return, @message