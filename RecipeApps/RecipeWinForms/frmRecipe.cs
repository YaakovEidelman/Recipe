using CPUFramework;
using System.Data;
using System.Diagnostics;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe = new();
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public void ShowForm(int id)
        {
            dtrecipe = Recipe.GetSpecificRecipe(id);
            if (id == 0)
            {
                dtrecipe.Rows.Add();
            }

            WinFormsUtility.SetListBinding(lstUserName, Recipe.GetStaffTable(), dtrecipe, "StaffId");
            WinFormsUtility.SetListBinding(lstCuisineType, Recipe.GetCuisineTable(), dtrecipe, "CuisineId");


            foreach (Control c in tblRecipeMain.Controls)
            {
                switch (c)
                {
                    case TextBox:
                        WinFormsUtility.SetControlBinding(c, dtrecipe);
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
