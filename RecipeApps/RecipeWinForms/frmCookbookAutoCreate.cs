namespace RecipeWinForms
{
    public partial class frmCookbookAutoCreate : Form
    {
        public frmCookbookAutoCreate()
        {
            InitializeComponent();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
            WinFormsUtility.SetListBinding(lstUserName, RecipeProject.GetAnyDataTable("StaffListGet", ("@All", 1)), null, "Staff");
        }

        private void AutoCreate()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                int newcookbookid = RecipeProject.AutoCreate(WinFormsUtility.GetIdFromComboBox(lstUserName));
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), newcookbookid);
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

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            AutoCreate();
        }
    }
}
