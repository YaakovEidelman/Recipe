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
            bool isdatedraftedblank = (txtDateDrafted.Text == "") ? true : false;
            Recipe.Save(dtrecipe, isdatedraftedblank);
            Close();
        }
        private void Delete()
        {
            Recipe.Delete(dtrecipe);
            Close();
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
