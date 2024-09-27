namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuDashboard.Click += MnuDashboard_Click;
            mnuRecipeList.Click += MnuRecipeList_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuMealsList.Click += MnuMealsList_Click;
            mnuCookbookList.Click += MnuCookbookList_Click;
            mnuNewCookbook.Click += MnuNewCookbook_Click;
            mnuEditData.Click += MnuEditData_Click;
            mnuCloneARecipe.Click += MnuCloneARecipe_Click;
            mnuAutoCreate.Click += MnuAutoCreate_Click;

            mnuTile.Click += MnuTile_Click;
            mnuCascade.Click += MnuCascade_Click;
            this.Shown += FrmMain_Shown;
        }

        public void OpenForm(Type frmtype, int id = 0)
        {
            Form? newfrm = null;

            bool b = WinFormsUtility.IsFormOpen(frmtype, id);
            if (!b)
            {
                if (frmtype == typeof(frmDashboard))
                {
                    newfrm = new frmDashboard();
                }
                else if (frmtype == typeof(frmRecipeList))
                {
                    newfrm = new frmRecipeList();
                }
                else if (frmtype == typeof(frmRecipeUpdated))
                {
                    frmRecipeUpdated f = new frmRecipeUpdated();
                    f.Tag = id;
                    newfrm = f;
                    f.MdiParent = this;
                    f.ShowRecipeDetailsForm(id);
                }
                else if (frmtype == typeof(frmChangeStatus))
                {
                    frmChangeStatus f = new frmChangeStatus();
                    f.Tag = id;
                    newfrm = f;
                    f.MdiParent = this;
                    f.DisplayChangeStatusForm(id);
                }
                else if (frmtype == typeof(frmMealList))
                {
                    newfrm = new frmMealList();
                }
                else if (frmtype == typeof(frmCookbookList))
                {
                    newfrm = new frmCookbookList();
                }
                else if (frmtype == typeof(frmCookbook))
                {
                    frmCookbook f = new();
                    f.Tag = id;
                    newfrm = f;
                    f.MdiParent = this;
                    f.ShowCookbookForm(id);
                }
                else if (frmtype == typeof(frmDataMaintenance))
                {
                    newfrm = new frmDataMaintenance();
                }
                else if (frmtype == typeof(frmCloneARecipe))
                {
                    newfrm = new frmCloneARecipe();
                }
                else if (frmtype == typeof(frmCookbookAutoCreate))
                {
                    newfrm = new frmCookbookAutoCreate();
                }

                if (newfrm != null)
                {
                    newfrm.MdiParent = this;
                    newfrm.WindowState = FormWindowState.Maximized;
                    newfrm.FormClosed += Newfrm_FormClosed;
                    newfrm.TextChanged += Newfrm_TextChanged;
                    if (frmtype != typeof(frmChangeStatus))
                    {
                        newfrm.Show();
                    }
                }
                WinFormsUtility.SetupNav(tsMain);
            }
        }

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }
        private void MnuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }
        private void MnuRecipeList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }
        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeUpdated), 0);
        }
        private void MnuMealsList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }
        private void MnuCookbookList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }
        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbook), 0);
        }
        private void MnuEditData_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }
        private void MnuCloneARecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCloneARecipe));
        }
        private void MnuAutoCreate_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookAutoCreate));
        }



        private void Newfrm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WinFormsUtility.SetupNav(tsMain);
        }
        private void Newfrm_TextChanged(object? sender, EventArgs e)
        {
            WinFormsUtility.SetupNav(tsMain);
        }

        private void MnuCascade_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void MnuTile_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        // End Class
    }
}
