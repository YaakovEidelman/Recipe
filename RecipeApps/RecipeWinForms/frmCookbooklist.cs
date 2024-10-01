namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        DataTable dtCookbookList = new();
        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbooklist_Activated;
            btnNewCookbook.Click += BtnNewCookbook_Click;
            gCookbooks.CellDoubleClick += GCookbooks_CellDoubleClick;
            gCookbooks.KeyDown += GCookbooks_KeyDown;
        }

        private void SetupTable()
        {
            dtCookbookList = RecipeProject.GetAnyDataTable("CookbookGet", ("@All", 1));
            gCookbooks.DataSource = dtCookbookList;
            WinFormsUtility.FormatGridSearchResults(gCookbooks, "Cookbook");
        }

        private void ShowCookbookDetails(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WinFormsUtility.GetIdFromGrid(gCookbooks, rowindex, "CookbookId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), id);
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        private void FrmCookbooklist_Activated(object? sender, EventArgs e)
        {
            SetupTable();
        }

        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            ShowCookbookDetails(-1);
        }

        private void GCookbooks_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowCookbookDetails(e.RowIndex);
        }

        private void GCookbooks_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && gCookbooks.SelectedRows.Count > 0)
            {
                ShowCookbookDetails(gCookbooks.SelectedRows[0].Index);
            }
        }


    }
}
