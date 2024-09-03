using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe = new();
        BindingSource bc = new();
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public void ShowForm(int id)
        {
            dtrecipe = Recipe.GetSpecificRecipe(id);
            bc.DataSource = dtrecipe;
            if (id == 0)
            {
                dtrecipe.Rows.Add();
            }

            WinFormsUtility.SetListBinding(lstUserName, Recipe.GetStaffTable(), dtrecipe, "Staff");
            WinFormsUtility.SetListBinding(lstCuisineType, Recipe.GetCuisineTable(), dtrecipe, "Cuisine");


            foreach (Control c in tblRecipeMain.Controls)
            {
                switch (c)
                {
                    case TextBox:
                        WinFormsUtility.SetControlBinding(c, bc);
                        break;
                }
            }
            Show();
        }

        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                bool isdatedraftedblank = (txtDateDrafted.Text == "") ? true : false;
                Recipe.Save(dtrecipe, isdatedraftedblank);
                bc.ResetBindings(false);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RecipeApp");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }
        private void Delete()
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this recipe?", "Recipe App", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                Application.UseWaitCursor = true;
                try
                {
                    Recipe.Delete(dtrecipe);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "RecipeApp");
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        //End of class
    }
}
