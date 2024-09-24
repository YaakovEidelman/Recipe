namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
            WinFormsUtility.FormatGridSearchResults(gDashboard, "");
        }

        private void RefreshDashboardData()
        {
            gDashboard.DataSource = RecipeProject.GetAnyDataTable("RecipeDashboardGet");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            RefreshDashboardData();
        }
        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            ((frmMain)this.MdiParent).OpenForm(typeof(frmMealList));
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeList));
        }
        // End of Class
    }
}
