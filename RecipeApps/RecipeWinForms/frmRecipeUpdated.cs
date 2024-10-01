namespace RecipeWinForms
{
    public partial class frmRecipeUpdated : Form
    {
        DataTable dtRecipe = new();
        BindingSource bs = new();
        DataTable dtRecipeIngredientsList = new();
        DataTable dtRecipeStepsList = new();
        List<Button> btn;
        int recipeid = 0;
        public frmRecipeUpdated()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnIngredientSave.Click += BtnIngredientSave_Click;
            btnStepsSave.Click += BtnStepsSave_Click;
            txtCalories.TextChanged += TxtCalories_TextChanged;
            this.Activated += FrmRecipeUpdated_Activated;
            this.Shown += FrmRecipeUpdated_Shown;
            this.FormClosing += FrmRecipeUpdated_FormClosing;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gSteps.CellContentClick += GSteps_CellContentClick;
            btn = new List<Button> { btnDelete, btnChangeStatus, btnIngredientSave, btnStepsSave };
        }

        public void ShowRecipeDetailsForm(int id)
        {
            recipeid = id;
            EnableDisableButtons();
            SetupRecipeDataTable();

            WinFormsUtility.SetControlBinding(txtRecipeName, bs);
            WinFormsUtility.SetControlBinding(lblRecipeStatus, bs);
            WinFormsUtility.SetControlBinding(txtCalories, bs);
            WinFormsUtility.SetControlBinding(lblDateDrafted, bs);
            WinFormsUtility.SetControlBinding(lblDateArchived, bs);
            WinFormsUtility.SetControlBinding(lblDatePublished, bs);
            DataTable dtstaff = RecipeProject.GetAnyDataTable("StaffGet", ("@All", 1));
            DataTable dtcuisine = RecipeProject.GetAnyDataTable("CuisineGet", ("@All", 1));
            WinFormsUtility.SetListBindingWithSource(lstUserName, dtstaff, bs, "Staff");
            WinFormsUtility.SetListBindingWithSource(lstCuisineType, dtcuisine, bs, "Cuisine");



            this.Text = UpdateTabText();
            this.Show();
        }

        private void SetupRecipeDataTable()
        {

            dtRecipe = RecipeProject.GetAnyDataTable("RecipeGet", ("@RecipeId", recipeid));
            bs.DataSource = dtRecipe;

            //if (recipeid == 0)
            //{
            //    dtRecipe.Rows.Add();
            //}
        }

        private void SetupIngredientDataTable()
        {
            dtRecipeIngredientsList = RecipeProject.GetAnyDataTable("RecipeIngredientGet", ("@RecipeId", recipeid));
            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtRecipeIngredientsList;
            WinFormsUtility.AddComboBoxToGrid(gIngredients, RecipeProject.GetAnyDataTable("MeasurementGet", ("@InsertBlank", 1)), "Measurement", "MeasurementType");
            WinFormsUtility.AddComboBoxToGrid(gIngredients, RecipeProject.GetAnyDataTable("IngredientGet"), "Ingredient", "IngredientName");
            WinFormsUtility.AddDeleteButtonToGrid(gIngredients, "Delete");
            WinFormsUtility.FormatGridForEdit(gIngredients, "");

        }

        private void SetupStepsDataTable()
        {
            dtRecipeStepsList = RecipeProject.GetAnyDataTable("RecipeDirectionGet", ("@RecipeId", recipeid));
            gSteps.Columns.Clear();
            gSteps.DataSource = dtRecipeStepsList;
            WinFormsUtility.AddDeleteButtonToGrid(gSteps, "Delete");
            WinFormsUtility.FormatGridForEdit(gSteps, "");
        }

        private void EnableDisableButtons()
        {
            btn.ForEach(btn =>
            {
                btn.Enabled = (recipeid > 0) ? true : false;
            });
        }

        private bool Save()
        {
            bool issaved = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.Save(dtRecipe, "RecipeUpdate");
                recipeid = (int)dtRecipe.Rows[0]["RecipeId"];
                issaved = true;
                EnableDisableButtons();
                this.Text = UpdateTabText();
                this.Tag = recipeid;
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete " + (string)dtRecipe.Rows[0]["RecipeName"] + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    RecipeProject.Delete(dtRecipe, "RecipeId", "RecipeDelete");
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

        private void RecipeIngredientSave()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.SaveSubTable(dtRecipeIngredientsList, recipeid, "RecipeIngredientUpdate", "RecipeId");
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

        private void RecipeStepsSave()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.SaveSubTable(dtRecipeStepsList, recipeid, "RecipeDirectionUpdate", "RecipeId");
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

        private void DeleteRowFromGrid(DataGridView grid, int rowindex, string colname, string sproc, bool isingredient)
        {
            int id = WinFormsUtility.GetIdFromGrid(grid, rowindex, colname);
            try
            {
                RecipeProject.DeleteSubTable(id, sproc, colname);
                if (isingredient)
                {
                    SetupIngredientDataTable();
                }
                else
                {
                    SetupStepsDataTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string UpdateTabText()
        {
            string val = "New Recipe";
            int i = SQLUtility.GetValueFromFristRowAsInt(dtRecipe, "RecipeId");
            if (i > 0)
            {
                val = SQLUtility.GetValueFromFristRowAsString(dtRecipe, "RecipeName");
            }
            return val;
        }

        private void PromptUserToSaveForm(FormClosingEventArgs e)
        {
            bs.EndEdit();
            if (dtRecipe.GetChanges() != null)
            {
                DialogResult dr = MessageBox.Show($"Do you want to save changes to {this.Text}?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        private void UpdateStatusFields()
        {
            dtRecipe = RecipeProject.GetAnyDataTable("RecipeGet", ("@RecipeId", recipeid));
            bs.DataSource = dtRecipe;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void FrmRecipeUpdated_Activated(object? sender, EventArgs e)
        {
            if (recipeid != 0)
            {
                UpdateStatusFields();
            }
            dtRecipe.AcceptChanges();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeStatus), recipeid);
        }

        private void BtnIngredientSave_Click(object? sender, EventArgs e)
        {
            RecipeIngredientSave();
        }

        private void BtnStepsSave_Click(object? sender, EventArgs e)
        {
            RecipeStepsSave();
        }

        private void TxtCalories_TextChanged(object? sender, EventArgs e)
        {
            if (sender is TextBox && sender != null)
            {
                WinFormsUtility.ReplaceLettersWithBlanks((TextBox)sender, false);
            }
        }

        private void FrmRecipeUpdated_Shown(object? sender, EventArgs e)
        {
            SetupIngredientDataTable();
            SetupStepsDataTable();
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gSteps.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DeleteRowFromGrid(gSteps, e.RowIndex, "RecipeDirectionId", "RecipeDirectionDelete", false);
                }
            }
        }

        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gIngredients.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DeleteRowFromGrid(gIngredients, e.RowIndex, "RecipeIngredientId", "RecipeIngredientDelete", true);
                }
            }
        }

        private void FrmRecipeUpdated_FormClosing(object? sender, FormClosingEventArgs e)
        {
            PromptUserToSaveForm(e);
        }

        // End of Class
    }
}
