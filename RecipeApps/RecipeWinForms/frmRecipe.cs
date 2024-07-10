using CPUFramework;
using System.Data;
using System.Diagnostics;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int id)
        {
            string sql = "select r.recipeid, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived from Recipe r where r.recipeid = " + id;
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            txtDateDrafted.DataBindings.Add("Text", dt, "DateDrafted");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            this.Show();
        }
    }
}
