-- SM Excellent! 100%
--use HeartyHearthDB
go
drop Table if exists CookBookRecipe
drop table if exists CookBook
drop table if exists MealCourseRecipe
drop table if exists MealCourse
drop table if exists Course
drop table if exists Meal
drop table if exists RecipeDirection
drop table if exists RecipeIngredient
drop table if exists Recipe
drop table if exists Measurement
drop table if exists Ingredient
drop table if exists Cuisine
drop table if exists Staff
go


create table dbo.Staff(
    StaffId int not null identity primary key,
    FirstName varchar(25) not null 
        constraint c_Staff_FirstName_Cannot_Be_Blank check(FirstName <> ''),
    LastName varchar(25) not null 
        constraint c_Staff_LastName_Cannot_Be_Blank check(LastName <> ''),
    UserName varchar(25) not null 
        constraint c_Staff_UserName_Cannot_Be_Blank check(UserName <> '')
        constraint u_Staff_UserName_Must_Be_Unique unique
)

------------------------------------------------------------------------------------------------------------------------------

create table dbo.Cuisine(
    CuisineId int not null identity primary key,
    CuisineType varchar(25) not null 
        constraint c_Cuisine_CuisineType_Cannot_Be_Blank check(CuisineType <> '')
        constraint u_Cuisine_CuisineType_Must_Be_Unique unique
)


create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(50) not null 
        constraint c_Ingredient_IngredientName_Cannot_Be_Blank check(IngredientName <> '')
        constraint u_Ingredient_IngredientName_Must_Be_Unique unique,
    IngredientImagePath as concat('Ingredient_', replace(IngredientName, ' ', '_'), '.jpeg')
)


create table dbo.Measurement(
    MeasurementId int not null identity primary key,
    MeasurementType varchar(20) not null 
        constraint c_Measurement_MeasurementType_Cannot_Be_Blank check(MeasurementType <> '')
        constraint u_Measurement_MeasurementType_Must_Be_Unique unique
)


create table dbo.Recipe(
    RecipeId int not null identity primary key,
    StaffId int not null 
        constraint f_Recipe_StaffId foreign key references Staff(StaffId),
    CuisineId int not null 
        constraint f_Recipe_Cuisine foreign key references Cuisine(CuisineId),
    RecipeName varchar(50) not null 
        constraint c_Recipe_RecipeName_Cannot_Be_Blank check(RecipeName <> '')
        constraint u_Recipe_RecipeName_Must_Be_Unique unique,
    Calories int not null
        constraint c_Recipe_Calories_Cannot_Be_Less_Than_Zero check(Calories >= 0),
    RecipeStatus as case 
                         when DatePublished is null and DateArchived is null
                            then 'Draft'
                        when DatePublished is not null and DateArchived is null
                            then 'Published'
                        else 'Archived'
                     end,
    DateDrafted datetime not null default getdate()
        constraint c_Recipe_DateDrafted_Cannot_Be_Future_Date check(DateDrafted <= getdate()),
    DatePublished datetime null
        constraint c_Recipe_DatePublished_Cannot_Be_Future_Date check(DatePublished <= getdate()),
    DateArchived datetime null
        constraint c_Recipe_DateArchived_Cannot_Be_Future_Date check(DateArchived <= getdate()),
    RecipeImagePath as concat('Recipe_', replace(RecipeName, ' ', '_'), '.jpeg'),
    constraint c_DatePulished_Must_Be_After_DateDrafted_and_DateArchived_Must_Be_After_DatePublished 
        check(DatePublished >= DateDrafted and DateArchived >= isnull(DatePublished, DateDrafted))
)


create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null 
        constraint f_RecipeIngredient_Recipe foreign key references Recipe(RecipeId),
    IngredientId int not null 
        constraint f_RecipeIngredient_Ingedient foreign key references Ingredient(IngredientId),
    MeasurementId int null 
        constraint f_RecipeIngredient_Measurement foreign key references Measurement(MeasurementId),
    Amount decimal(4, 2) not null
        constraint c_RecipeIngredient_Amount_Cannot_Be_Less_Than_Zero check(Amount >= 0),
    IngredientOrderNum int not null
        constraint c_RecipeIngredient_IngredientOrderNum_Cannot_Be_Less_Than_Zero check(IngredientOrderNum > 0),
    constraint u_RecipeId_and_IngredientId_Must_Be_Unique unique(RecipeId, IngredientId),
    constraint u_RecipeId_and_IngredientOrderNum_Must_Be_Unique unique(RecipeId, IngredientOrderNum)
)


create table dbo.RecipeDirection(
    RecipeDirectionId int not null identity primary key,
    RecipeId int not null 
        constraint f_RecipeDirection_Recipe foreign key references Recipe(RecipeId),
    StepNum int not null 
        constraint c_RecipeDirection_StepNum_Cannot_Be_Less_Than_One check(StepNum > 0),
    DirectionText varchar(1000) not null
        constraint c_RecipeDirection_DirectionText_Cannot_Be_Blank check(DirectionText <> ''),
    constraint u_RecipeId_and_StepNum_Must_Be_Unique unique(RecipeId, StepNum)
)

-----------------------------------------------------------------------------------------------------------------------------

create table dbo.Meal(
    MealId int not null identity primary key,
    StaffId int not null 
        constraint f_Meal_Staff foreign key references Staff(StaffId),
    MealName varchar(25) not null
        constraint c_Meal_MealName_Cannot_Be_Blank check(MealName <> '')
        constraint u_Meal_MealName_Must_Be_Unique unique,
    DateCreated date not null default getdate()
        constraint c_Meal_DateCreated_Cannot_Be_Future_Date check(DateCreated <= getdate()),
    IsActive bit not null default 1,
    MealImagePath as concat('Meal_', replace(MealName, ' ', '_'), '.jpeg')
)


create table dbo.Course(
    CourseId int not null identity primary key,
    CourseType varchar(25) not null 
        constraint c_Course_CourseType_Cannot_Be_Blank check(CourseType <> '')
        constraint u_Course_CourseType_Must_Be_Unique unique,
    CourseSequenceNum int not null 
        constraint c_Course_CourseSequenceNum_Cannot_Be_Blank check(CourseSequenceNum <> '')
        constraint u_Course_CourseSequenceNum_Must_Be_Unique unique 
)


create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null
        constraint f_MealCourse_Meal foreign key references Meal(MealId),
    CourseId int not null
        constraint f_MealCourse_Course foreign key references Course(CourseId),
    constraint u_MealCourse_MealId_and_CourseId_Must_Be_Unique unique(MealId, CourseId)
)


create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null
        constraint f_MealCourseRecipe_MealCourse foreign key references MealCourse(MealCourseId),
    RecipeId int not null
        constraint f_MealCourseRecipe_Recipe foreign key references Recipe(RecipeId),
    IsMain bit not null,
    constraint u_MealCourseRecipe_MealCourseId_and_RecipeId_Must_Be_Unique unique(MealCourseId, RecipeId)
)

---------------------------------------------------------------------------------------------------------------------------------------------------------

create table dbo.CookBook(
    CookBookId int not null identity primary key,
    StaffId int not null 
        constraint f_CookBook_StaffId foreign key references Staff(StaffId),
    CookBookName varchar(50) not null
        constraint c_CookBook_CookBookName_Cannot_Be_Blank check(CookBookName <> '')
        constraint u_CookBook_CookBookName_Must_Be_Unique unique,
    Price decimal(5, 2) not null 
        constraint c_CookBook_Price_Must_Be_Greater_Than_Zero check(Price > 0),
    IsActive bit not null default 1,
    DateCreated date not null default getdate()
        constraint c_CookBook_DateCreated_Cannot_A_Future_Date check(DateCreated <= getdate()),
    CookBookImagePath as concat('CookBook_', replace(CookBookName, ' ', '_'), '.jpeg')
)


create table dbo.CookBookRecipe(
    CookBookRecipeId int not null identity primary key,
    CookBookId int not null 
        constraint f_CookBookRecipe_CookBook foreign key references CookBook(CookBookId),
    RecipeId int not null
        constraint f_CookBookRecipe_Recipe foreign key references Recipe(RecipeId),
    RecipeSequence int not null
        constraint c_CookBookRecipe_RecipeSequence_Must_Be_Greater_Than_Zero check(RecipeSequence > 0),
    constraint u_CookBookRecipe_CookBookId_and_RecipeId_Must_Be_Unique unique(CookBookId, RecipeId),
    constraint u_CookBookRecipe_CookBookId_and_RecipeSequence_Must_Be_Unique unique(CookBookId, RecipeSequence)
)