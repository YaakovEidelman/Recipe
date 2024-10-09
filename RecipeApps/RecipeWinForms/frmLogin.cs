using System.Configuration;

namespace RecipeWinForms
{
    public partial class frmLogin : Form
    {
        bool loginsuccess = false;
        public frmLogin()
        {
            InitializeComponent();
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public bool ShowLogin()
        {
#if DEBUG
            this.Text = this.Text + " - DEV";
#endif
            txtUsername.Text = Settings.Default.username;
            txtPassword.Text = Settings.Default.password;
            ShowDialog();
            return loginsuccess;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            string connkey = "";
#if DEBUG
            connkey = "devconn";
#else
            connkey = "liveconn";
#endif
            try
            {
                Settings.Default.username = txtUsername.Text;
                Settings.Default.password = txtPassword.Text;
                Settings.Default.Save();
                string connstring = ConfigurationManager.ConnectionStrings[connkey].ConnectionString;
                DBManager.SetConnString(connstring, true, txtUsername.Text, txtPassword.Text);
                loginsuccess = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Login Failed, Try agian.", Application.ProductName);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
