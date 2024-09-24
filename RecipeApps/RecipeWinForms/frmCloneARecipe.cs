namespace RecipeWinForms
{
    public partial class frmCloneARecipe : Form
    {
        DataTable dtRecipe = new();
        public frmCloneARecipe()
        {
            InitializeComponent();
            dtRecipe = RecipeProject.GetAnyDataTable("RecipeGetForCookbookDropdown");
            WinFormsUtility.SetListBinding(lstRecipeName, dtRecipe, null, "Recipe");
            btnClone.Click += BtnClone_Click;
        }

        private void Clone()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                int id = WinFormsUtility.GetIdFromComboBox(lstRecipeName);
                id = RecipeProject.Clone(id);
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeUpdated), id);
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

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            Clone();
        }
    }
}