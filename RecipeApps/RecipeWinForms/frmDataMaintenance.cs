using Microsoft.VisualBasic.ApplicationServices;
using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        DataTable dt = new();
        enum SelectedOption { Staff, Cuisine, Ingredient, Measurement, Course };
        SelectedOption so = SelectedOption.Staff;
        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            gData.CellContentClick += GData_CellContentClick;
            SetupRadioButtons();
        }

        private void SetupGrid(SelectedOption tableenum)
        {
            so = tableenum;
            dt = RecipeProject.GetAnyDataTable(so + "Get", ("@All", 1), ("@IsDataMaint", 1));
            gData.Columns.Clear();
            gData.DataSource = dt;
            WinFormsUtility.FormatGridForEdit(gData, so.ToString());
            WinFormsUtility.AddDeleteButtonToGrid(gData, "Delete");
        }

        private void SetupRadioButtons()
        {
            optStaff.Tag = SelectedOption.Staff;
            optCuisine.Tag = SelectedOption.Cuisine;
            optIngredient.Tag = SelectedOption.Ingredient;
            optMeasurement.Tag = SelectedOption.Measurement;
            optCourse.Tag = SelectedOption.Course;

            foreach (Control c in flpOptions.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }

        }
        private void Save()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                RecipeProject.SaveSubTable(dt, null, so + "Update", "");
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

        private void Delete(int rowindex)
        {
            int id = WinFormsUtility.GetIdFromGrid(gData, rowindex, so + "Id");
            DialogResult dr;
            if (id != 0)
            {
                if (so.ToString() == "Staff")
                {
                    dr = MessageBox.Show("Are you sure you want to delete this user and all related recipes, meals, and cookbooks ?", Application.ProductName, MessageBoxButtons.YesNo);
                }
                else
                {
                    dr = MessageBox.Show("Are you sure you want to delete this Record?", Application.ProductName, MessageBoxButtons.YesNo);
                }
                Cursor = Cursors.WaitCursor;
                try
                {
                    if (dr == DialogResult.Yes)
                    {
                        RecipeProject.DeleteSubTable(id, so + "Delete", so + "Id");
                        SetupGrid(so);
                    }
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
            else if (id == 0 && rowindex < gData.Rows.Count)
            {
                try
                {
                    gData.Rows.RemoveAt(rowindex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender != null && sender is RadioButton && ((RadioButton)sender).Tag is SelectedOption)
            {
                SetupGrid((SelectedOption)((RadioButton)sender).Tag);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gData.Columns[e.ColumnIndex].Name == "Delete")
                {
                    Delete(e.RowIndex);
                }
            }
        }

        //End Class
    }
}