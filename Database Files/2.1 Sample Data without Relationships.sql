delete Recipe

insert Recipe (StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select 1, 1, 'Pancakes', 150, '01/28/2023', null, null
union select 2, 2, 'Chocalate cake', 250, '05/14/2023', '06/18/2024', '07/13/2024'
union select 3, 3, 'MeatBalls', 200, '01/21/2023', '02/08/2024', null
union select 4, 4, 'Spinach Pie', 58, '03/28/2024', '04/17/2024', '06/10/2024'
union select 5, 5, 'French Toast', 150, '01/28/2023', null, '05/04/2024'