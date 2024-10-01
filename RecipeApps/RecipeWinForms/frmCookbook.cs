using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCookbook : Form
    {
        DataTable dtcookbook = new();
        BindingSource bs = new();
        DataTable dtcookbookrecipes = new();
        DataTable dtrecipe = new();
        List<Button> btn;

        int cookbookid = 0;
        public frmCookbook()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSaveRecipes.Click += BtnSaveRecipes_Click;
            txtPrice.TextChanged += TxtPrice_TextChanged;
            gCookbookRecipes.CellContentClick += GCookbookRecipes_CellContentClick;
            this.FormClosing += FrmCookbook_FormClosing;
            this.Shown += FrmCookbook_Shown;
            btn = new() { btnDelete, btnSaveRecipes };
        }

        public void ShowCookbookForm(int id)
        {
            cookbookid = id;
            dtcookbook = RecipeProject.GetAnyDataTable("CookbookGet", ("@CookbookId", id));
            bs.DataSource = dtcookbook;

            //Instead of adding in a row here, I put it in the sproc which I think makes more sense, since adding a row is technically SQL.
            //if (id == 0)
            //{
            //    dtcookbook.Rows.Add();
            //}

            WinFormsUtility.SetControlBinding(txtCookbookName, bs);
            WinFormsUtility.SetListBinding(lstUserName, RecipeProject.GetAnyDataTable("StaffListGet", ("@All", 1)), dtcookbook, "Staff");
            WinFormsUtility.SetControlBinding(txtPrice, bs);
            WinFormsUtility.SetControlBinding(txtDateCreated, bs);
            WinFormsUtility.SetControlBinding(chkIsActive, bs);

            UpdateDeleteAndRecipeSaveButton();
            this.Text = UpdateTabText();
            this.Show();
        }

        private void SetupCookbookRecipesTable()
        {
            dtcookbookrecipes = RecipeProject.GetAnyDataTable("CookbookRecipeGet", ("@CookbookId", cookbookid));
            dtrecipe = RecipeProject.GetAnyDataTable("RecipeGetForCookbookDropdown");
            gCookbookRecipes.Columns.Clear();
            gCookbookRecipes.DataSource = dtcookbookrecipes;
            WinFormsUtility.AddComboBoxToGrid(gCookbookRecipes, dtrecipe, "Recipe", "RecipeName");
            WinFormsUtility.AddDeleteButtonToGrid(gCookbookRecipes, "Delete");
            WinFormsUtility.FormatGridForEdit(gCookbookRecipes, "CookbookRecipe");
        }

        private string UpdateTabText()
        {
            string s = "New Cookbook";
            if (cookbookid > 0)
            {
                s = "Cookbook - " + (string)dtcookbook.Rows[0]["CookbookName"];
            }
            return s;
        }

        private void UpdateDeleteAndRecipeSaveButton()
        {
            bool isenabled = (cookbookid == 0) ? false : true;
            btn.ForEach(b => b.Enabled = isenabled);
        }

        private bool Save()
        {
            bool issaved = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.Save(dtcookbook, "CookbookUpdate");
                issaved = true;
                cookbookid = (int)dtcookbook.Rows[0]["CookbookId"];
                UpdateDeleteAndRecipeSaveButton();
                this.Text = UpdateTabText();
                this.Tag = cookbookid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return issaved;
        }

        private void Delete()
        {
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete {this.Text}", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    RecipeProject.Delete(dtcookbook, "CookbookId", "CookbookDelete");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        private void SaveRecipes()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.SaveSubTable(dtcookbookrecipes, cookbookid, "CookbookRecipeUpsert", "CookbookId");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DeleteRowFromGrid(int rowindex)
        {
            int id = WinFormsUtility.GetIdFromGrid(gCookbookRecipes, rowindex, "CookbookRecipeId");
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.DeleteSubTable(id, "CookbookRecipeDelete", "CookbookRecipeId");
                SetupCookbookRecipesTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void PromptUserBeforeClosing(FormClosingEventArgs e)
        {
            bs.EndEdit();
            if (dtcookbook.GetChanges() != null)
            {
                DialogResult dr = MessageBox.Show($"Do you want to save changes to {this.Text}", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (!b)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////

        private void FrmCookbook_Shown(object? sender, EventArgs e)
        {
            SetupCookbookRecipesTable();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnSaveRecipes_Click(object? sender, EventArgs e)
        {
            SaveRecipes();
        }

        private void TxtPrice_TextChanged(object? sender, EventArgs e)
        {
            if (sender is TextBox && sender != null)
            {
                WinFormsUtility.ReplaceLettersWithBlanks((TextBox)sender);
            }
        }

        private void GCookbookRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gCookbookRecipes.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DeleteRowFromGrid(e.RowIndex);
                }
            }
        }

        private void FrmCookbook_FormClosing(object? sender, FormClosingEventArgs e)
        {
            PromptUserBeforeClosing(e);
        }
    }
}
