using CPUFramework;
using RecipeSystem;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RecipeTest
{
    public class Tests
    {
        string liveconn = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;
        //string devconn = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnString(liveconn, true);
        }

        [Test]
        [TestCase(1, 1, "Gambies", 1, null, null, null)]
        [TestCase(2, 3, "Salmon", 342, "2022-1-1", "2023-1-1", "2024-1-1")]
        [TestCase(4, 5, "Crunchie Pops", 201, "2022-1-1", "2023-1-1", null)]
        [TestCase(2, 7, "Cro-cro", 159, "2022-1-1", null, null)]
        public void CreateRecipe(int staffid, int cuisineid, string recipename, int calories, object drafted, object published, object archived)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();

            TestContext.WriteLine("Check if we can insert a recipe");
            string newrecipename = recipename + " " + DateTime.Now.ToString("HH:mm:ss");

            r["staffid"] = staffid;
            r["cuisineid"] = cuisineid;
            r["recipename"] = newrecipename; // + " " + DateTime.Now.ToString("HH:mm:ss");
            r["calories"] = calories;

            if (drafted == null)
            {
                drafted = DBNull.Value;
            }
            if (published == null)
            {
                published = DBNull.Value;
            }
            if (archived == null)
            {
                archived = DBNull.Value;
            }

            r["datedrafted"] = (drafted is null) ? "" : drafted;
            r["datepublished"] = published;
            r["datearchived"] = archived;

            bool isdatedraftedblank = (r["datedrafted"].ToString() == "") ? true : false;
            RecipeProject.Save(dt, "RecipeUpdate");

            TestContext.WriteLine("The new recipe name is " + recipename);
            DataTable newrecipetable = SQLUtility.GetDataTable("select r.recipeid from recipe r where r.recipename = " + "'" + newrecipename + "'");
            int newrecipeid = (int)newrecipetable.Rows[0][0];
            Assert.IsTrue(newrecipeid > 0, "Inserting recipe was unsuccessful");
            TestContext.WriteLine("Successfully inserted a new recipe: " + recipename);
        }

        [Test]
        public void ReadRecipe()
        {
            int id = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe");
            Assume.That(id > 0, "There are not recipes in the DB, can't run test");
            TestContext.WriteLine("See if we can access data from the database properly");
            TestContext.WriteLine("There is a recipe in the DB with an id of " + id);
            TestContext.WriteLine("Ensure that the app loads the recipe with the id of " + id);
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = " + id);
            int loadedid = (int)dt.Rows[0]["recipeid"];
            Assert.IsTrue(id == loadedid, "Was not able load recipe from DB properly");
            TestContext.WriteLine("Loaded recipe with id " + loadedid);
        }

        [Test]
        [TestCase(1, 1, "Gambies", 4, null, null, null)]
        [TestCase(2, 3, "Salmon", 344, "2022-1-2", "2023-1-2", "2024-1-2")]
        [TestCase(4, 5, "Crunchie Pops", 200, "2022-1-2", "2023-1-2", null)]
        [TestCase(2, 7, "Cro-cro", 15, "2022-1-2", null, null)]
        public void UpdateRecipe(int staffid, int cuisineid, string recipename, int calories, object drafted, object published, object archived)
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe where recipename like " + "'%" + recipename + "%'");
            Assume.That(dt.Rows.Count > 0, "There are no rows in the table, can't test");
            int id = (int)dt.Rows[0]["recipeid"];
            DataRow r = dt.Rows[0];

            TestContext.WriteLine("Checking if we can update a recipe");

            r["staffid"] = staffid;
            r["cuisineid"] = cuisineid;
            r["recipename"] = recipename;
            r["calories"] = calories;

            if (drafted == null)
            {
                drafted = DBNull.Value;
            }
            if (published == null)
            {
                published = DBNull.Value;
            }
            if (archived == null)
            {
                archived = DBNull.Value;
            }

            r["datedrafted"] = (drafted is null) ? "" : drafted;
            r["datepublished"] = published;
            r["datearchived"] = archived;

            bool isdatedraftedblank = (r["datedrafted"].ToString() == "") ? true : false;
            Recipe.Save(dt, isdatedraftedblank);

            TestContext.WriteLine("Updating " + recipename);

            DataTable newinfo = SQLUtility.GetDataTable("select r.recipename, r.calories, r.datedrafted from recipe r where r.recipeid = " + id);
            string newrecipename = (string)newinfo.Rows[0]["recipename"];
            int newrecipecalories = (int)newinfo.Rows[0]["calories"];

            TestContext.WriteLine("RecipeName should be: " + recipename + Environment.NewLine + "RecipeName is: " + newrecipename);
            TestContext.WriteLine("Calories should be: " + calories + Environment.NewLine + "Calories is: " + newrecipecalories);


            Assert.IsTrue(
                newrecipename == recipename &&
                (int)newrecipecalories == calories, "Updating recipe was unsuccessful"
                );
            TestContext.WriteLine("Successfully updated recipe: " + recipename);
        }

        [Test]
        public void UpdateRecipeCheckException()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe");
            Assume.That(dt.Rows.Count > 0, "There are no rows in the table, can't run test");
            int id = (int)dt.Rows[0]["recipeid"];
            DataRow r = dt.Rows[0];
            TestContext.WriteLine("Check that when breaking a check constraint it throws an error");
            TestContext.WriteLine("RecipeName is " + r["recipename"]);
            TestContext.WriteLine("Try renaming to a blank");

            r["recipename"] = "";
            Exception ex = Assert.Throws<Exception>(() => RecipeProject.Save(dt, "RecipeUpdate"));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void UpdateRecipeUniqueException()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 2 * from recipe");
            Assume.That(dt.Rows.Count > 0, "There are no rows in the table, can't run test");
            int id1 = (int)dt.Rows[0]["recipeid"];
            int id2 = (int)dt.Rows[1]["recipeid"];
            DataRow r1 = dt.Rows[0];
            DataRow r2 = dt.Rows[1];
            TestContext.WriteLine("Check that when breaking a unique constraint it throws an error");
            TestContext.WriteLine("RecipeName is " + r1["recipename"]);
            TestContext.WriteLine("Try renaming " + r1["recipename"] + " to " + r2["recipename"]);

            r1["recipename"] = r2["recipename"];
            Exception ex = Assert.Throws<Exception>(() => RecipeProject.Save(dt, "RecipeUpdate"));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe r left join recipeingredient ri on r.recipeid = ri.recipeid where ri.recipeid is null");
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(id > 0, "No eligable recipes in db, cannot delete");
            TestContext.WriteLine("Check that the app can delete the recipe with an id of " + id);
            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + id);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Was not able to delete the recipe");
            TestContext.WriteLine("Successfully deleted recipe with the id of " + id);
        }

        [Test]
        public void DeleteRecipeCheckForbussinessRule()
        {
            string sql = @"
select * 
from Recipe r 
where r.RecipeStatus in ('Published')
or datediff(day, r.DateArchived, current_timestamp) < 30";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(id > 0, "No eligable recipes in db, cannot check for bussiness rule");
            TestContext.WriteLine("Check that the app prevents deleting recipe with a bussiness rule");
            TestContext.WriteLine("Trying to delete recipe with an id of " + id);
            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeForeignKeyException()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid from recipe r left join recipeingredient ri on r.recipeid = ri.recipeid where ri.recipeid is not null");
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(id > 0, "there is no data in the row, can't run test");
            TestContext.WriteLine("Check that an exception is thrown when trying to delete a recipe with related tables");
            TestContext.WriteLine("Trying to delete recipe with recipeid of " + id);
            Exception ex = Assert.Throws<Exception>(() => RecipeProject.Delete(dt, "RecipeId", "RecipeDelete"));
            TestContext.WriteLine(ex.Message);

            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
            cmd.Parameters["@recipeid"].Value = id;
            DataTable newdt = SQLUtility.GetDataTable(cmd);
            TestContext.WriteLine("The recipeid with an id of " + newdt.Rows[0]["recipeid"] + " still exists");
        }

        public static string GetFirstColumnFirstRowValueAsString(string sql)
        {
            string val = "";
            DataTable dt = SQLUtility.GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    val = dt.Rows[0][0].ToString();
                }
            }
            return val;
        }

        //End of class
    }
}