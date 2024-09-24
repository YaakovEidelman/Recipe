namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        DataTable dtrecipelist = new();
        List<string> DisplayColumns = new List<string>() { "RecipeName", "RecipeStatus", "Username", "Calories", "NumIngredients" };
        public frmRecipeList()
        {
            InitializeComponent();
            SetupDataTable();

            btnNewRecipe.Click += BtnNewRecipe_Click;
            gRecipeList.CellDoubleClick += GRecipeList_CellDoubleClick;
            gRecipeList.KeyDown += GRecipeList_KeyDown;
            this.Activated += FrmRecipeList_Activated;
            WinFormsUtility.FormatGridSearchResults(gRecipeList, "");
            FormatListDataForDisplay();
        }

        private void SetupDataTable()
        {
            dtrecipelist = RecipeProject.GetAnyDataTable("RecipeListGet");
            gRecipeList.DataSource = dtrecipelist;
        }

        private void ShowRecipeEditForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WinFormsUtility.GetIdFromGrid(gRecipeList, rowindex, "RecipeId");
                //(int)gRecipeList.Rows[rowindex].Cells["RecipeId"].Value;
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeUpdated), id);
            }
        }

        private void FormatListDataForDisplay()
        {
            foreach (DataGridViewColumn c in gRecipeList.Columns)
            {
                c.Visible = false;
            }
            DisplayColumns.ForEach(c => { gRecipeList.Columns[c].Visible = true; });
        }


        ///////////////////////////////////////////////////////////////////////////
        private void BtnNewRecipe_Click(object? sender, EventArgs e)
        {
            ShowRecipeEditForm(-1);
        }
        private void GRecipeList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex != -1)
            {
                ShowRecipeEditForm(e.RowIndex);
            }
        }
        private void GRecipeList_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && gRecipeList.SelectedRows.Count > 0)
            {
                ShowRecipeEditForm(gRecipeList.SelectedRows[0].Index);
            }
        }
        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            SetupDataTable();
        }
        // End of Class
    }
}
