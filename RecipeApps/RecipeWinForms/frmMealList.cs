namespace RecipeWinForms
{
    public partial class frmMealList : Form
    {
        DataTable dtMealsList = new();
        public frmMealList()
        {
            InitializeComponent();
            this.Activated += FrmMealList_Activated;
        }

        private void FrmMealList_Activated(object? sender, EventArgs e)
        {
            dtMealsList = RecipeProject.GetAnyDataTable("MealGet");
            gMealsList.DataSource = dtMealsList;
            WinFormsUtility.FormatGridSearchResults(gMealsList, "Meal");
        }
    }
}
