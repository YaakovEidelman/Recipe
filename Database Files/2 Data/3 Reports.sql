-- SM Excellent! 100%
/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/

select Item = 'Recipes', count(r.RecipeId) as Count
from Recipe r 
union select 'Meals', count(m.MealId)
from Meal m
union select 'CookBooks', count(cb.CookBookId)
from CookBook cb

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/

select case r.RecipeStatus
            when 'Archived'
                then concat('<span style="color:gray">', r.RecipeName, '</span>')
            else r.RecipeName
       end 
       as RecipeName, 
       r.RecipeStatus,
       isnull(convert(varchar(10), r.DatePublished, 101), '') as DatePublished,
       isnull(convert(varchar(10), r.DateArchived, 101), '') as DateArchived,
       s.UserName,
       r.Calories,
       count(ri.RecipeIngredientId) as NumIngredients
from Recipe r 
join Staff s 
on r.StaffId = s.StaffId
join RecipeIngredient ri
on r.RecipeId = ri.RecipeId
where r.RecipeStatus <> 'draft'
group by r.RecipeName, r.RecipeStatus, r.DatePublished, r.DateArchived, s.UserName, r.Calories
order by 
    case r.RecipeStatus
        when 'Published'
            then 1
        when 'Archived' 
            then 2
    end


/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories, count(distinct ri.RecipeIngredientId) as NumIngredients, count(distinct rd.DirectionText) as NumSteps, r.RecipeImagePath
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
left join RecipeDirection rd 
on r.RecipeId = rd.RecipeId
where r.RecipeName = 'Pound Cake'
group by r.RecipeName, r.Calories, r.RecipeImagePath


select count(rd.RecipeId) 
from RecipeDirection rd
join Recipe r 
on rd.RecipeId = r.RecipeId
where r.RecipeName = 'Pound cake'
group by rd.RecipeId



select 
    concat(
            ri.Amount,
            case 
                when m.MeasurementType is null 
                    then ''
                else ' '
            end,
            m.MeasurementType, 
            ' ', 
            i.IngredientName
        ) as MeasurementInfo,
        i.IngredientImagePath
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
left join Measurement m 
on ri.MeasurementId = m.MeasurementId
left join Ingredient i 
on ri.IngredientId = i.IngredientId
where r.RecipeName = 'Chocolate Chip Cookies'
order by ri.IngredientOrderNum


select rd.DirectionText
from RecipeDirection rd
join Recipe r 
on r.RecipeId = rd.RecipeId
where r.RecipeName = 'Chocolate Chip Cookies'
order by rd.StepNum


/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/

select m.MealName, 
       s.UserName, 
       sum(r.Calories) as CaloriesPerMeal, 
       count(distinct mc.CourseId) as NumCourses, 
       count(distinct mcr.MealCourseRecipeId) as NumRecipes
from Meal m
join Staff s 
on m.StaffId = s.StaffId
join MealCourse mc 
on m.MealId = mc.MealId
join MealCourseRecipe mcr 
on mc.MealCourseId = mcr.MealCourseId
join Recipe r 
on mcr.RecipeId = r.RecipeId
where m.IsActive = 1
group by m.MealName, s.UserName
order by m.MealName


/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/


select m.MealName, s.UserName, m.DateCreated, m.MealImagePath
from Meal m 
join Staff s 
on m.StaffId = s.StaffId
where m.MealName = 'Midday Munch'


select 
    case 
        when c.CourseType = 'Main Course' and mcr.IsMain = 1
            then concat('<b>', c.CourseType, ': Main dish - ', r.RecipeName, '</b>')
        when c.CourseType = 'Main Course' and mcr.IsMain = 0
            then concat(c.CourseType, ': Side dish - ', r.RecipeName)
        else concat(c.CourseType, ': ', r.RecipeName)
    end as MealDetails
from Meal m 
join MealCourse mc 
on m.MealId = mc.MealId
join MealCourseRecipe mcr 
on mc.MealCourseId = mcr.MealCourseId
join Course c 
on mc.CourseId = c.CourseId
join Recipe r 
on mcr.RecipeId = r.RecipeId
where m.MealName = 'Midday Munch'


/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/

select cb.CookBookName, s.UserName, count(cbr.CookBookRecipeId) as RecipesInBook
from CookBook cb 
join Staff s 
on cb.StaffId = s.StaffId
join CookBookRecipe cbr 
on cb.CookBookId = cbr.CookBookId
where cb.IsActive = 1
group by cb.CookBookName, s.UserName
order by cb.CookBookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/


select cb.CookBookName, s.UserName, cb.DateCreated, cb.Price, count(cbr.CookBookRecipeId) as RecipesInBook, cb.CookBookImagePath
from CookBook cb 
join Staff s 
on cb.StaffId = s.StaffId
join CookBookRecipe cbr 
on cb.CookBookId = cbr.CookBookId
where cb.CookBookName = 'Treats for Two'
group by cb.CookBookName, s.UserName, cb.DateCreated, cb.Price, cb.CookBookImagePath


select r.RecipeName, c.CuisineType, count(distinct ri.RecipeIngredientId) as NumIngredients, count(distinct rd.RecipeDirectionId) as NumSteps
from CookBook cb 
join CookBookRecipe cbr 
on cb.CookBookId = cbr.CookBookId
join Recipe r 
on cbr.RecipeId = r.RecipeId
join Cuisine c 
on r.CuisineId = c.CuisineId
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join RecipeDirection rd 
on r.RecipeId = rd.RecipeId
where cb.CookBookName = 'Treats for Two'
group by r.RecipeName, c.CuisineType, cbr.RecipeSequence
order by cbr.RecipeSequence


/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/

select distinct 
    concat(upper(left(reverse(r.RecipeName), 1)), substring(lower(reverse(r.RecipeName)), 2, len(r.RecipeName) - 1)) as RecipeName,
    concat(
            'Recipe_', 
            translate(
                concat(
                    upper(left(reverse(r.RecipeName), 1)), substring(lower(reverse(r.RecipeName)), 2, len(r.RecipeName) - 1)
                ), 
                ' .,!@#$%^&*()-+=;:<>/?[]{}\|"''', 
                '______________________________'
            ),
            '.jpg'
        ) as RecipeImagePath
from CookBook cb 
join CookBookRecipe cbr 
on cb.CookBookId = cbr.CookBookId
join Recipe r 
on cbr.RecipeId = r.RecipeId


;with x as(
    select distinct r.RecipeName, count(distinct rd.RecipeDirectionId) as LastRecipeStepNum
    from CookBook cb 
    join CookBookRecipe cbr 
    on cb.CookBookId = cbr.CookBookId
    join Recipe r 
    on cbr.RecipeId = r.RecipeId
    join RecipeDirection rd 
    on r.RecipeId = rd.RecipeId
    group by r.RecipeName
)
select rd.DirectionText
from x 
join Recipe r 
on x.RecipeName = r.RecipeName
join RecipeDirection rd 
on r.RecipeId = rd.RecipeId 
and rd.StepNum = x.LastRecipeStepNum


/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/


select s.UserName, 
        sum(case when r.RecipeStatus = 'Draft' then 1 else 0 end) as Draft,
        sum(case when r.RecipeStatus = 'Published' then 1 else 0 end) as Published, 
        sum(case when r.RecipeStatus = 'Archived' then 1 else 0 end) as Archived
from Staff s 
join Recipe r 
on s.StaffId = r.StaffId
group by s.UserName


select s.UserName, count(r.RecipeId) as NumRecipes, avg(datediff(day, r.DateDrafted, r.DatePublished)) as AvgDaysUntilPublished
from Staff s 
join Recipe r 
on s.StaffId = r.StaffId
group by s.UserName


select 
    s.UserName, 
    count(m.MealId) as NumMeals,
    sum(case when m.IsActive = 1 then 1 else 0 end) as ActiveMeals,
    sum(case when m.IsActive = 0 then 1 else 0 end) as InActiveMeals
from Staff s 
left join Meal m 
on s.StaffId = m.StaffId
group by s.UserName


select 
    s.UserName,
    count(cb.CookBookId) as NumCookBooks,
    sum(case when cb.IsActive = 1 then 1 else 0 end) as ActiveBooks,
    sum(case when cb.IsActive = 0 then 1 else 0 end) as InActiveBooks
from Staff s  
left join CookBook cb
on cb.StaffId = s.StaffId
group by s.UserName


select r.RecipeName, datediff(day, r.DateDrafted, r.DateArchived) as DaysUntilArchived
from Recipe r 
where r.DatePublished is null
and r.DateArchived is not null 
group by r.RecipeName, r.DateDrafted, r.DateArchived


/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
    
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/


select s.UserName, 'Recipes' as ItemType, count(r.recipeId) as Amount
from Staff s 
left join Recipe r 
on s.StaffId = r.StaffId
where s.UserName = 'xrod95'
group by s.UserName
union select s.UserName, 'Meals', count(m.MealId)
from Staff s 
left join Meal m 
on s.StaffId = m.StaffId
where s.UserName = 'xrod95'
group by s.UserName
union select s.UserName, 'CookBooks', count(cb.CookBookId)
from Staff s 
left join CookBook cb 
on s.StaffId = cb.StaffId
where s.UserName = 'xrod95'
group by s.UserName


-- Other way
-- ;with x as (
--     select s.StaffId, s.UserName
--     from Staff s 
--     where s.UserName = 'xrod95'
-- )
-- select x.UserName, 'Recipes' as ItemType, count(r.recipeId) as Amount
-- from x 
-- left join Recipe r 
-- on x.StaffId = r.StaffId
-- group by x.UserName
-- union select x.UserName, 'Meals', count(m.MealId)
-- from x 
-- left join Meal m 
-- on x.StaffId = m.StaffId
-- group by x.UserName
-- union select x.UserName, 'CookBooks', count(cb.CookBookId)
-- from x 
-- left join CookBook cb 
-- on x.StaffId = cb.StaffId
-- group by x.UserName



select 
    s.UserName, 
    r.RecipeName, 
    r.RecipeStatus, 
    datediff(
        hour,
        case
            when r.DateArchived is not null and r.DatePublished is not null
                then r.DatePublished
            else r.DateDrafted
        end,
        case 
            when r.DateArchived is not null and r.DatePublished is not null
                then r.DateArchived
            when r.DateArchived is null 
                then r.DatePublished
            when r.DatePublished is null 
                then r.DateArchived
        end
    ) as StatusHourDiff
from Staff s 
join Recipe r 
on s.StaffId = r.StaffId
where s.UserName = 'xrod95'
and r.RecipeStatus <> 'Draft'



;with x as(
    select r.RecipeId, r.CuisineId
    from Recipe r 
    join Staff s 
    on r.StaffId = s.StaffId
    where s.UserName = 'xrod95'
)
select c.CuisineType, count(x.RecipeId) as RecipePerCuisine
from Cuisine c 
left join x 
on c.CuisineId = x.CuisineId
group by c.CuisineType
