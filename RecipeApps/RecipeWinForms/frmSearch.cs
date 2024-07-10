using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            FormatGrid();
        }

        private void ShowRecipeForm(int rowindex)
        {
            // In the session he did like this:
            int id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            //Why cant you do as follows:
            //frm.ShowForm(rowindex);
            //Like this you dont need to get the id in the function you already have it passed into the function

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
        private void FormatGrid()
        {
            gRecipe.ReadOnly = true;
            gRecipe.AllowUserToAddRows = false;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtSearch.Text);
        }
    }
}
