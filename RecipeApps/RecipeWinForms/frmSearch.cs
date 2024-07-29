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
            btnNew.Click += BtnNew_Click;
            WinFormsUtility.FormatGridSearchResults(gRecipe);
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            }
            frmRecipe frm = new();
            frm.ShowForm(id);
        }
        private void SearchForRecipe(string recipename)
        {
            DataTable dt = Recipe.GetRecipeSearchResults(recipename);
            gRecipe.DataSource = dt;
            gRecipe.Columns["recipeid"].Visible = false;
            gRecipe.Columns["StaffId"].Visible = false;
            gRecipe.Columns["cuisineid"].Visible = false;
        }


        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex != -1)
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