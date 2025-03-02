

ALTER TABLE Recipe ADD IsVegan BIT NOT NULL DEFAULT 0
GO
ALTER TABLE Meal ADD MealDesc VARCHAR(255) NOT NULL DEFAULT ''
GO
 ALTER TABLE Cookbook ADD SkillLevel INT NOT NULL DEFAULT 1
 GO
 ALTER TABLE Cookbook ADD SkillDesc as (
     CASE 
         WHEN SkillLevel = 1 THEN 'Beginner'
         WHEN SkillLevel = 2 THEN 'Intermediate'
         WHEN SkillLevel = 3 THEN 'Advanced'
     END
 ) PERSISTED
GO
select * from recipe

UPDATE recipe
SET isvegan = CASE 
    WHEN recipe.RecipeName IN ('Pound Cake', 'Chocolate Chip Cookies', 'Matzah Balls', 'Butter Muffins', 'Chocolate Cake', 'French Toast') THEN 0
    WHEN recipe.RecipeName IN ('Apple Yogurt Smoothie', 'Cheese Bread', 'MeatBalls', 'Spinach Pie') THEN 0
    WHEN recipe.RecipeName IN ('Tomato Salad', 'Pancakes') THEN 1
    ELSE isvegan
END;
GO
SELECT * FROM Meal

UPDATE Meal
SET MealDesc = CASE 
    WHEN MealName = 'Midday Munch' THEN 'A light and satisfying meal perfect for the middle of the day.'
    WHEN MealName = 'Breakfast Bash' THEN 'A hearty and delicious breakfast to kick-start your morning.'
    WHEN MealName = 'Ultimate Dinner' THEN 'A filling and flavorful dinner for a perfect evening meal.'
    WHEN MealName = 'Homestyle Supper' THEN 'A comforting homemade supper with a traditional touch.'
    ELSE MealDesc
END;
GO
select * from CookBook

UPDATE Cookbook
SET SkillLevel = CASE 
    WHEN CookBookName = 'Treats for Two' THEN 1
    WHEN CookBookName = 'Family Favorites Cookbook' THEN 3
    WHEN CookBookName = 'Flavorful Favorites' THEN 2
    WHEN CookBookName = 'Quick and Easy Recipes' THEN 3
    ELSE SkillLevel
END;
