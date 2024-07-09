-- SM Excellent! 100%
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.

--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.

-- Delete Cookbooks
delete cbr
--select * 
from CookBook cb 
join Staff s 
on cb.StaffId = s.StaffId
join CookBookRecipe cbr
on cb.CookBookId = cbr.CookBookId
where s.UserName = 'natep84'


delete cb
--select * 
from CookBook cb 
join Staff s 
on cb.StaffId = s.StaffId
where s.UserName = 'natep84'


-- Delete Meals
delete mcr
--select *
from Meal m 
join Staff s 
on m.StaffId = s.StaffId
join MealCourse mc 
on m.MealId = mc.MealId
join MealCourseRecipe mcr 
on mc.MealCourseId = mcr.MealCourseId
where s.UserName = 'natep84'


delete mc
--select *
from Meal m 
join Staff s 
on m.StaffId = s.StaffId
join MealCourse mc 
on m.MealId = mc.MealId
where s.UserName = 'natep84'


delete m
--select *
from Meal m 
join Staff s 
on m.StaffId = s.StaffId
where s.UserName = 'natep84'


-- Delete Recipes
delete cbr 
--select *
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId 
join CookBookRecipe cbr 
on r.RecipeId = cbr.RecipeId
where s.UserName = 'natep84'


delete mcr 
--select *
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId 
join MealCourseRecipe mcr  
on r.RecipeId = mcr.RecipeId
where s.UserName = 'natep84'


delete ri
--select *
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
where s.UserName = 'natep84'


delete rd 
--select *
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId 
join RecipeDirection rd
on r.RecipeId = rd.RecipeId
where s.UserName = 'natep84'


delete r
--select *
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId 
where s.UserName = 'natep84'


delete s
--select *
from Staff s 
where s.UserName = 'natep84'


--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.

insert Recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select s.StaffId, c.CuisineId, concat(r.RecipeName, ' - clone'), r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId
join Cuisine c 
on r.CuisineId = c.CuisineId
where r.RecipeName = 'Pound Cake'


insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientOrderNum)
select (
    select r.RecipeId from Recipe r where r.RecipeName = 'Pound Cake - clone'
), ri.IngredientId, ri.MeasurementId, ri.Amount, ri.IngredientOrderNum
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
where r.RecipeName = 'Pound Cake'


insert RecipeDirection(RecipeId, StepNum, DirectionText)
select (
    select r.RecipeId from Recipe r where r.RecipeName = 'Pound Cake - clone'
), rd.StepNum, rd.DirectionText
from Recipe r 
join RecipeDirection rd 
on r.RecipeId = rd.RecipeId
where r.RecipeName = 'Pound Cake'


/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/


insert CookBook(StaffId, CookBookName, Price, IsActive, DateCreated)
select s.StaffId, concat('Recipes by ', s.FirstName, ' ', s.LastName), count(r.RecipeId) * 1.33, 1, current_timestamp
from Staff s 
join Recipe r 
on s.StaffId = r.StaffId
where s.UserName = 'liv_martinez'
group by s.StaffId, s.FirstName, s.LastName


insert CookBookRecipe(CookBookId, RecipeId, RecipeSequence)
select cb.CookBookId, r.RecipeId, row_number() over (order by r.RecipeName)
from CookBook cb 
join Staff s 
on cb.StaffId = s.StaffId
join Recipe r 
on s.StaffId = r.StaffId
where s.UserName = 'liv_martinez'
and cb.CookBookName = concat('Recipes by ', s.FirstName, ' ', s.LastName)


/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/

update r 
set r.Calories = 
	case m.MeasurementType
		when 'Cup' 
			then r.Calories + (4 * ri.Amount)
		when 'Tsp'
			then r.Calories + (1 * ri.Amount)
		when 'Tbsp'
			then r.Calories + (2 * ri.Amount)
	end
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Ingredient i 
on ri.IngredientId = i.IngredientId
join Measurement m 
on ri.MeasurementId = m.MeasurementId
where i.IngredientName = 'Sugar'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;with x as(
	select avg(datediff(hour, r.DateDrafted, r.DatePublished)) as AvgHoursInDraft
	from Recipe r
)
select 
	s.FirstName, 
	s.LastName, 
	concat(substring(s.FirstName, 1, 1), s.LastName, '@heartyhearth.com') as Email, 
	concat(
		'Your Recipe ', 
		r.RecipeName, 
		' is sitting in draft for ', 
		datediff(hour, r.DateDrafted, current_timestamp), 
		' hours. That is ', 
		datediff(hour, r.DateDrafted, current_timestamp) - x.AvgHoursInDraft, 
		' hours more than the average ',
		 x.AvgHoursInDraft, 
		 ' hours all other recipes took to be published.'
		 ) as Alert
from Staff s 
join Recipe r 
on s.StaffId = r.StaffId
cross join x
where datediff(hour, r.DateDrafted, getdate()) > x.AvgHoursInDraft
and r.RecipeStatus = 'Draft'



/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/

select 
	concat(
		'Order cookbooks from HeartyHearth.com! We have ', 
		count(cb.CookBookId),
		' books for sale, average price is ',
		format(round(avg(cb.Price), 2), '0.##'),
		'. ',
		'You can order them all and receive a 25% discount, for a total of ',
		sum(cb.Price) - sum(cb.Price) * 0.25,
		'. ',
		'Click <a href = "www.heartyhearth.com/order/',
		newid(),
		'">here</a> to order'
	) as EmailBody
from 
CookBook cb 