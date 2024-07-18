using CPUFramework;
using System.Data;
using System.Diagnostics;
using CPUWinFormFramwork;

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
            string sql = "select r.recipeid, r.StaffId, r.CuisineId, r.RecipeName, r.Calories, r.RecipeStatus, r.DateDrafted, r.DatePublished, r.DateArchived from Recipe r where r.recipeid = " + id;
            dtrecipe = SQLUtility.GetDataTable(sql);
            if (id == 0)
            {
                dtrecipe.Rows.Add();
            }

            DataTable dtstaff = SQLUtility.GetDataTable("select s.StaffId, s.username from Staff s");
            DataTable dtCuisine = SQLUtility.GetDataTable("select c.CuisineId, c.CuisineType from Cuisine c");
            WinFormsUtility.SetListBinding(lstUserName, dtstaff, dtrecipe, "StaffId");
            WinFormsUtility.SetListBinding(lstCuisineType, dtCuisine, dtrecipe, "CuisineId");



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
            string sql;
            DataRow dr = dtrecipe.Rows[0];
            int id = (int)dr["recipeid"];
            string published = string.IsNullOrEmpty(dr["DatePublished"].ToString()) ? "null" : $"'{dr["DatePublished"]}'";
            string archived = string.IsNullOrEmpty(dr["DateArchived"].ToString()) ? "null" : $"'{dr["DateArchived"]}'";

            if (id > 0)
            {
                sql = string.Join(
                    Environment.NewLine,
                    $"update r set ",
                    $"r.RecipeName = '{dr["RecipeName"]}',",
                    $"r.Calories = {dr["Calories"]},",
                    $"r.DateDrafted = '{dr["DateDrafted"]}',",
                    $"r.DatePublished = {published},",
                    $"r.DateArchived = {archived}",
                    $"from recipe r where r.recipeid = {dr["recipeid"]}"
                );
            }
            else
            {
                if(txtDateDrafted.Text == "")
                {
                    sql = "insert recipe(StaffId, CuisineId, RecipeName, Calories, DatePublished, DateArchived)";
                    sql += $"select '{dr["StaffId"]}', '{dr["CuisineId"]}', '{dr["RecipeName"]}', {dr["Calories"]}, {published}, {archived}";
                }
                else
                {
                    sql = "insert recipe(StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)";
                    sql += $"select '{dr["StaffId"]}', '{dr["CuisineId"]}', '{dr["RecipeName"]}', {dr["Calories"]}, '{dr["DateDrafted"]}', {published}, {archived}";
                }
            }

            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);

            Close();
        }
        private void Delete()
        {
            DataRow dr = dtrecipe.Rows[0];
            int id = (int)dr["RecipeId"];
            string sql = "delete recipe where recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
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
