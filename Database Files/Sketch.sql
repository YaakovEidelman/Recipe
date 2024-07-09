-- SM Excellent sketch! See comments, no need to resubmit. Good luck on creating the DB!!!
-- Sketch for Hearty Hearth Project


/*

STAFF TABLES

Table Name: Staff

StaffId primary key,
FirstName varchar(25) not null, not blank
LastName varchar(25) not null, not blank
UserName varchar(25) not null, not blank, unique

*/



/*

RECIPE TABLES

Table Name: Cuisine

CuisineId primary key,
CuisineType varchar(25) not null, unique, not blank


Table Name: Ingredient

IngredientId primary key,
IngredientName varchar(50) not null, not blank, unique
IngredientImage Computed Ingredient_[IngredientName].jpeg


Table Name: Measurment

MeasurmentId primary key,
MeasurmentType varchar(20) not null, not blank, unique



Table Name: Recipe

RecipeId primary key,
StaffId foreign key,
CuisineId foreign key
RecipeName varchar(25) not null, not blank, unique
Calories int not null, not less than zero
Status computed based on the dates.
DateDrafted datetime not null,
DatePublished datetime null,
DateArchived datetime null
RecipeImage as Recipe_[Recipe_Name].jpeg

constraints:
-- SM You need to include that drafted is before archived. You need it if published is null but archived not.
datedrafted is before datepublished, datepublished is before archived.


Table Name: RecipeIngredient

RecipeIngredientId primary key,
RecipeId foreign key,
IngredientId foreign key,
MeasurmentId foreign key null,
Amount decimal(4, 2) not null, not less than zero,
IngredientOrderNum int not null, not less than zero

consraints: 
recipe and ingredient unique
recipeid and ingredientordernum unique


Table Name: RecipeDirection 

RecipeDirectionId primary key,
RecipeId foreign key,
StepNum int not null not less than zero
DirectionText varchar(1000) not null not blank

constraints: 
recipeId, stepnum must be unique
*/



/*

MEALS TABLES

Table Name: Meal

MealId primary key,
StaffId foreign key,
MealName varchar(25) not null, not blank, unique
DateCreated date not null
IsActive bit not null
MealImage as Meal_[Image_Name].jpeg


Table Name: Course

CourseId primary key,
CourseType varchar(25) not null, not blank, unique
CourseSequenceNum int not null, not less than zero, unique

Table Name: MealCourse 

MealCourseId primary key,
MealId foreign key,
CourseId Foreign key,


Constraints: 
MealId and CourseId must be unique

-- SM Name table MealCourseRecipe
Table Name: MCRecipe

MCRecipeId primary key,
MealCourseId foreign key,
RecipeId Foreign key,
IsMain bit not null (0 is side, 1 is main)

constraints: 
unique mealcourseid and recipeid

*/



/*

COOKBOOK TABLES

Table Name: CookBook

CookBookId primary key,
StaffId foreign key,
Name varchar(25) not null, not blank, unique
Price decimal(5, 2) not null, not less than zero
Active bit not null
DateCreated date not null
CookBookImage as Cookbook_[CookBook_Name].jpeg


Table Name: CookbookRecipe

CookbookRecipeId primary key,
CookbookId foreign key,
RecipeId foreign key,
RecipeSequence int not null, not less than 0

constraints:
unique cookbookid and recipeid
recipesequence and cookbookid is unique

*/


