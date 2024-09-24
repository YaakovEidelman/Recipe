--use HeartyHearthDB
delete CookBookRecipe
delete CookBook
delete MealCourseRecipe
delete MealCourse
delete Course
delete Meal
delete RecipeDirection
delete RecipeIngredient
delete Recipe
delete Measurement
delete Ingredient
delete Cuisine
delete Staff
go


insert Staff(FirstName, LastName, UserName)
      select 'Eleanor', 'Johnson', 'ellyj22'
union select 'Xavier', 'Rodriguez', 'xrod95'
union select 'Isabella', 'Nguyen', 'bellanguy'
union select 'Nathan', 'Patel', 'natep84'
union select 'Olivia', 'Martinez', 'liv_martinez'

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

insert Cuisine(CuisineType)
      select 'Italian'
union select 'Mexican'
union select 'French'
union select 'Chinese'
union select 'American'
union select 'English'
union select 'Jewish'


insert Ingredient(IngredientName)
      select 'Sugar'
union select 'Oil'
union select 'Egg'
union select 'Flour'
union select 'Vanilla Sugar'
union select 'Baking Powder'
union select 'Baking Soda'
union select 'Chocolate Chips'
union select 'Granny Smith Apple'
union select 'Vanilla Yogurt'
union select 'Orange Juice'
union select 'Honey'
union select 'Ice Cube'
union select 'Club Bread'
union select 'Butter'
union select 'Shredded Cheese'
union select 'Crushed Garlic Clove'
union select 'Black Pepper'
union select 'Salt'
union select 'Stick Butter'
union select 'Vanilla Pudding'
union select 'Whipped Cream Cheese'
union select 'Sour Cream Cheese'
union select 'Tomato'
union select 'Water'
union select 'Lemon Juice'
union select 'Scallion'
union select 'Matzah Meal'
union select 'Apple'
union select 'Cinnamon'


insert Measurement(MeasurementType)
      select 'Cup'
union select 'Tsp'
union select 'Tbsp'
union select 'Oz'
union select 'Pinch'


;with x as (
          select UserName = 'ellyj22', CuisineType = 'American', Recipe = 'Chocolate Chip Cookies', Calories = 138, DateDrafted = '05-09-2023', DatePublished = '06-23-2023', DateArchived = null
    union select 'bellanguy', 'French', 'Apple Yogurt Smoothie', 169, '03-11-2020', '08-22-2020', '11-19-2022'
    union select 'natep84', 'English', 'Cheese Bread', 250, '04-13-2022', null, null
    union select 'xrod95', 'American', 'Butter Muffins', 200, '09-18-2023', '10-11-2023', null
    union select 'liv_martinez', 'Italian', 'Tomato Salad', 306, '12-20-2016', null, '02-12-2017'
    union select 'bellanguy', 'American', 'Pound Cake', 109, '06-16-2022', '11-05-2023', null
    union select 'ellyj22', 'Jewish', 'Matzah Balls', 48, '04-13-2023', '04-20-2023', null
)
insert Recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select s.StaffId, c.CuisineId, x.Recipe, x.Calories, x.DateDrafted, x.DatePublished, x.DateArchived
from x 
join Staff s 
on s.UserName = x.UserName
join Cuisine c 
on c.CuisineType = x.CuisineType


;with x as (
    select RecipeName = 'Chocolate Chip Cookies', IngredientName = 'Sugar', MeasurementType = 'Cup', Amount = 1, IngredientOrderNum = 1
    union select 'Chocolate Chip Cookies', 'Oil', 'Cup', 0.5, 2
    union select 'Chocolate Chip Cookies', 'Egg', null, 3, 3
    union select 'Chocolate Chip Cookies', 'Flour', 'Cup', 2, 4
    union select 'Chocolate Chip Cookies', 'Vanilla Sugar', 'Tsp', 1, 5
    union select 'Chocolate Chip Cookies', 'Baking Powder', 'Tsp', 2, 6
    union select 'Chocolate Chip Cookies', 'Baking Soda', 'Tsp', 0.5, 7
    union select 'Chocolate Chip Cookies', 'Chocolate Chips', 'Cup', 1, 8
    union select 'Apple Yogurt Smoothie', 'Granny Smith Apple', null, 3, 1
    union select 'Apple Yogurt Smoothie', 'Vanilla Yogurt', 'Cup', 2, 2
    union select 'Apple Yogurt Smoothie', 'Sugar', 'Tsp', 2, 3
    union select 'Apple Yogurt Smoothie', 'Orange Juice', 'Cup', 0.5, 4
    union select 'Apple Yogurt Smoothie', 'Honey', 'Tbsp', 2, 5
    union select 'Apple Yogurt Smoothie', 'Ice Cube', null, 5, 6 -- DOUBLE CHECK THAT I DON'T NEED TO INPUT 5 OR 6
    union select 'Cheese Bread', 'Club Bread', null, 1, 1
    union select 'Cheese Bread', 'Butter', 'Oz', 4, 2
    union select 'Cheese Bread', 'Shredded Cheese', 'Oz', 8, 3
    union select 'Cheese Bread', 'Crushed Garlic Clove', null, 2, 4
    union select 'Cheese Bread', 'Black Pepper', 'Tsp', 0.25, 5
    union select 'Cheese Bread', 'Salt', 'Pinch', 1, 6
    union select 'Butter Muffins', 'Stick Butter', null, 1, 1
    union select 'Butter Muffins', 'Sugar', 'Cup', 3, 2
    union select 'Butter Muffins', 'vanilla pudding', 'tbsp', 2, 3
    union select 'Butter Muffins', 'egg', null, 4, 4
    union select 'Butter Muffins', 'whipped cream cheese', 'oz', 8, 5
    union select 'Butter Muffins', 'sour cream cheese', 'oz', 8, 6
    union select 'Butter Muffins', 'flour', 'cup', 1, 7
    union select 'Butter Muffins', 'baking powder', 'tsp', 2, 8
    union select 'Tomato Salad', 'Tomato', null, 5, 1
    union select 'Tomato Salad', 'Oil', 'Cup', 0.25, 2
    union select 'Tomato Salad', 'Water', 'Tbsp', 2, 3
    union select 'Tomato Salad', 'Lemon Juice', 'Tbsp', 1, 4
    union select 'Tomato Salad', 'Sugar', 'Tbsp', 1, 5
    union select 'Tomato Salad', 'Scallion', null, 2, 6
    union select 'Pound Cake', 'Flour', 'Cup', 4, 1
    union select 'Pound Cake', 'Orange Juice', 'Cup', 1, 2
    union select 'Pound Cake', 'Egg', null, 5, 3
    union select 'Pound Cake', 'Vanilla Sugar', 'Tsp', 2, 4
    union select 'Pound Cake', 'Sugar', 'Cup', 3, 5
    union select 'Pound Cake', 'Oil', 'Cup', 1, 6
    union select 'Pound Cake', 'Water', 'Cup', 1, 7
    union select 'Pound Cake', 'Baking Powder', 'Tsp', 8, 8
    union select 'Matzah Balls', 'Matzah Meal', 'Cup', 1, 1
    union select 'Matzah Balls', 'Oil', 'Cup', 0.33, 2
    union select 'Matzah Balls', 'Water', 'Cup', 0.5, 3
    union select 'Matzah Balls', 'Salt', 'Tsp', 1, 4
    union select 'Matzah Balls', 'Egg', null, 4, 5
)
insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientOrderNum)
select r.RecipeId, i.IngredientId, m.MeasurementId, x.Amount, x.IngredientOrderNum
from x 
join Recipe r 
on r.RecipeName = x.RecipeName
join Ingredient i 
on i.IngredientName = x.IngredientName
left join Measurement m 
on m.MeasurementType = x.MeasurementType


;with x as (
    select RecipeName = 'Chocolate Chip Cookies', StepNum = 1, DirectionText = 'First combine sugar, oil and eggs in a bowl'
    union select 'Chocolate Chip Cookies', 2, 'Mix well'
    union select 'Chocolate Chip Cookies', 3, 'Add flour, vanilla sugar, baking powder and baking soda'
    union select 'Chocolate Chip Cookies', 4, 'Beat for 5 minutes'
    union select 'Chocolate Chip Cookies', 5, 'Add chocolate chips'
    union select 'Chocolate Chip Cookies', 6, 'Freeze for 1-2 hours'
    union select 'Chocolate Chip Cookies', 7, 'Roll into balls and place spread out on a cookie sheet'
    union select 'Chocolate Chip Cookies', 8, 'Bake on 350 for 10 min'
    union select 'Apple Yogurt Smoothie', 1, 'Peel the apples and dice'
    union select 'Apple Yogurt Smoothie', 2, 'Combine all ingredients in bowl except for apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 3, 'Mix until smooth'
    union select 'Apple Yogurt Smoothie', 4, 'Add apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 5, 'Pour into glasses'
    union select 'Cheese Bread', 1, 'Slit bread every 3/4 inch'
    union select 'Cheese Bread', 2, 'Combine all ingredients in bowl'
    union select 'Cheese Bread', 3, 'Fill slits with cheese mixture'
    union select 'Cheese Bread', 4, 'Wrap bread into a foil and bake for 30 minutes'
    union select 'Butter Muffins', 1, 'Cream butter with sugars'
    union select 'Butter Muffins', 2, 'Add eggs and mix well'
    union select 'Butter Muffins', 3, 'Slowly add rest of ingredients and mix well'
    union select 'Butter Muffins', 4, 'fill muffin pans 3/4 full and bake for 30 minutes'
    union select 'Tomato Salad', 1, 'Dice up tomatoes, and the Scallions, mix together'
    union select 'Tomato Salad', 2, 'Mix all liquids together'
    union select 'Tomato Salad', 3, 'Mix everything into a large bowl'
    union select 'Pound Cake', 1, 'Mix everything together'
    union select 'Pound Cake', 2, 'Pour into a baking pan'
    union select 'Pound Cake', 3, 'Bake on 375 °F for 1 hour'
    union select 'Matzah Balls', 1, 'Mix all ingredients together'
    union select 'Matzah Balls', 2, 'Boil a pot of water'
    union select 'Matzah Balls', 3, 'Add a little salt to pot'
    union select 'Matzah Balls', 4, 'Scoop out batter into balls'
    union select 'Matzah Balls', 5, 'Drop balls into boiling water as you make them'
    union select 'Matzah Balls', 6, 'cook for 20 minutes'
)
insert RecipeDirection(RecipeId, StepNum, DirectionText)
select r.RecipeId, x.StepNum, x.DirectionText
from x 
join Recipe r 
on r.RecipeName = x.RecipeName

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

;with x as (
    select UserName = 'liv_martinez', MealName = 'Breakfast Bash', DateCreated = '07-02-2019', IsActive = 1
    union select 'liv_martinez', 'Ultimate Dinner', '09-20-2023', 0
    union select 'natep84', 'Homestyle Supper', '12-06-2022', 1
    union select 'ellyj22', 'Midday Munch', '02-15-2024', 1
)
insert Meal(StaffId, MealName, DateCreated, IsActive)
select s.StaffId, x.MealName, x.DateCreated, x.IsActive
from x 
join Staff s 
on s.UserName = x.UserName


insert Course(CourseType, CourseSequenceNum)
      select 'Appetizer', 1
union select 'Soup/Salad', 2
union select 'Main Course', 3
union select 'Dessert', 4


;with x as (
          select MealName = 'Breakfast Bash', CourseType = 'Main Course'
    union select 'Breakfast Bash', 'Appetizer'
    union select 'Ultimate Dinner', 'Appetizer'
    union select 'Ultimate Dinner', 'Main Course'
    union select 'Ultimate Dinner', 'Dessert'
    union select 'Homestyle Supper', 'Main Course'
    union select 'Midday Munch', 'Appetizer'
    union select 'Midday Munch', 'Main Course'
)
insert MealCourse(MealId, CourseId)
select m.MealId, c.CourseId 
from x 
join Meal m 
on m.MealName = x.MealName
join Course c 
on c.CourseType = x.CourseType


;with x as(
    select MealName = 'Breakfast Bash', CourseType = 'Main Course', RecipeName = 'Cheese Bread', IsMain = 1
    union select 'Breakfast Bash', 'Main Course', 'Butter Muffins', 0
    union select 'Breakfast Bash', 'Appetizer', 'Apple Yogurt Smoothie', 1
    union select 'Ultimate Dinner', 'Appetizer', 'Butter Muffins', 1
    union select 'Ultimate Dinner', 'Main Course', 'Tomato Salad', 0
    union select 'Ultimate Dinner', 'Main Course', 'Pound Cake', 1
    union select 'Ultimate Dinner', 'Dessert', 'Chocolate Chip Cookies', 1
    union select 'Homestyle Supper', 'Main Course', 'Pound Cake', 0
    union select 'Homestyle Supper', 'Main Course', 'Apple Yogurt Smoothie', 0
    union select 'Homestyle Supper', 'Main Course', 'Cheese Bread', 1
    union select 'Midday Munch', 'Appetizer', 'Tomato Salad', 1
    union select 'Midday Munch', 'Main Course', 'Chocolate Chip Cookies', 0
)
insert MealCourseRecipe(MealCourseId, RecipeId, IsMain)
select mc.MealCourseId, r.RecipeId, x.IsMain
from x 
join Meal m 
on x.MealName = m.MealName
join Course c 
on x.CourseType = c.CourseType
join MealCourse mc 
on m.MealId = mc.MealId
and c.CourseId = mc.CourseId
join Recipe r 
on x.RecipeName = r.RecipeName


insert CookBook(StaffId, CookBookName, Price, IsActive, DateCreated)
      select (select StaffId from Staff where UserName = 'xrod95'), 'Treats for Two', 30, 0, '05-17-2022'
union select (select StaffId from Staff where UserName = 'bellanguy'), 'Family Favorites Cookbook', 40, 1, '02-16-2023'
union select (select StaffId from Staff where UserName = 'natep84'), 'Flavorful Favorites', 75, 1, '11-08-2023'
union select (select StaffId from Staff where UserName = 'liv_martinez'), 'Quick and Easy Recipes', 15, 0, '10-19-2021'


;with x as(
          select CookBook = 'Treats for Two', Recipe = 'Chocolate Chip Cookies', RecipeSequence = 1
    union select 'Treats for Two', 'Apple Yogurt Smoothie',  2
    union select 'Treats for Two', 'Cheese Bread', 3
    union select 'Treats for Two', 'Butter Muffins', 4
    union select 'Family Favorites Cookbook', 'Tomato Salad', 1
    union select 'Family Favorites Cookbook', 'Pound Cake', 3
    union select 'Flavorful Favorites', 'Apple Yogurt Smoothie', 1
    union select 'Flavorful Favorites', 'Tomato Salad', 2
    union select 'Flavorful Favorites', 'Butter Muffins', 3
    union select 'Quick and Easy Recipes', 'Butter Muffins', 1
    union select 'Quick and Easy Recipes', 'Apple Yogurt Smoothie', 2
    union select 'Quick and Easy Recipes', 'Tomato Salad', 3
    union select 'Quick and Easy Recipes', 'Cheese Bread', 5
)
insert CookBookRecipe(CookBookId, RecipeId, RecipeSequence)
select cb.CookBookId, r.RecipeId, x.RecipeSequence
from x 
join CookBook cb 
on x.CookBook = cb.CookBookName
join Recipe r 
on x.Recipe = r.RecipeName