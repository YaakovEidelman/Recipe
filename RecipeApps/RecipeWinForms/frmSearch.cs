using CPUFramework;
using System.Data;
using CPUWinFormFramwork;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
            WinFormsUtility.FormatGridSearchResults(gRecipe);
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                // In the session he did like this:
                id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
                //Why cant you do as follows:
                //frm.ShowForm(rowindex);
                //Like this you dont need to get the id in the function you already have it passed into the function
            }

            frmRecipe frm = new();
            frm.ShowForm(id);
        }
        private void SearchForRecipe(string recipename)
        {
            string sql = "select r.recipeid, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived from Recipe r where r.RecipeName like '%" + recipename + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipe.DataSource = dt;
            gRecipe.Columns["recipeid"].Visible = false;
        }


        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
                ShowRecipeForm(e.RowIndex);
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtSearch.Text);
        }
        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }
        //End of class
    }
}
