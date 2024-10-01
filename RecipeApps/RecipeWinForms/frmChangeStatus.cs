namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        DataTable dtRecipeTable = new();
        BindingSource bs = new();
        int recipeid = 0;
        enum RecipeStatus { DateDrafted, DatePublished, DateArchived };

        string recipename = "";

        public frmChangeStatus()
        {
            InitializeComponent();
            btnDraft.Click += Btn_Click;
            btnPublish.Click += Btn_Click;
            btnArchive.Click += Btn_Click;
        }

        public void DisplayChangeStatusForm(int id)
        {
            recipeid = id;
            dtRecipeTable = RecipeProject.GetAnyDataTable("RecipeGet", ("@RecipeId", recipeid));
            bs.DataSource = dtRecipeTable;

            if (bs.Count > 0)
            {
                recipename = (string)dtRecipeTable.Rows[0]["RecipeName"];
                WinFormsUtility.SetControlBinding(lblRecipeName, bs);
                WinFormsUtility.SetControlBinding(lblRecipeStatus, bs);
                WinFormsUtility.SetControlBinding(lblDateDrafted, bs);
                WinFormsUtility.SetControlBinding(lblDatePublished, bs);
                WinFormsUtility.SetControlBinding(lblDateArchived, bs);
            }

            this.Text = recipename + " - Change Status";
            this.Show();
            DisableCurrentStatusButton();
        }

        private void SetCurrentDate(RecipeStatus? currentstatus)
        {
            switch (currentstatus)
            {
                case RecipeStatus.DateDrafted:
                    dtRecipeTable.Rows[0][RecipeStatus.DatePublished.ToString()] = DBNull.Value;
                    dtRecipeTable.Rows[0][RecipeStatus.DateArchived.ToString()] = DBNull.Value;
                    break;
                case RecipeStatus.DatePublished:
                    dtRecipeTable.Rows[0][RecipeStatus.DateArchived.ToString()] = DBNull.Value;
                    break;
            }
            dtRecipeTable.Rows[0][currentstatus.ToString()] = DateTime.Now.TimeOfDay.ToString();
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.Save(dtRecipeTable, "RecipeUpsert");
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

        private void DisableCurrentStatusButton()
        {
            foreach (Control c in tblButtons.Controls)
            {
                c.Enabled = true;
            }
            switch (lblRecipeStatus.Text)
            {
                case "Draft":
                    btnDraft.Enabled = false;
                    break;
                case "Published":
                    btnPublish.Enabled = false;
                    break;
                case "Archived":
                    btnArchive.Enabled = false;
                    break;
            }
        }

        private bool PromptUserBeforeUpdatingStatus(string status)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to change this recipe to " + status + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void UpdateStatus(Button status)
        {
            if (PromptUserBeforeUpdatingStatus((string)status.Tag))
            {
                RecipeStatus? rs = null;
                switch ((string)status.Tag)
                {
                    case "Drafted":
                        rs = RecipeStatus.DateDrafted;
                        break;
                    case "Published":
                        rs = RecipeStatus.DatePublished;
                        break;
                    case "Archived":
                        rs = RecipeStatus.DateArchived;
                        break;
                }
                if (rs != null)
                {
                    SetCurrentDate(rs);
                    DisableCurrentStatusButton();
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        private void Btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                UpdateStatus((Button)sender);
            }
        }

        //End of Class
    }
}
