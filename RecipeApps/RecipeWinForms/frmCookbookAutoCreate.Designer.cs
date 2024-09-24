namespace RecipeWinForms
{
    partial class frmCookbookAutoCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            lstUserName = new ComboBox();
            btnCreateCookbook = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstUserName, 0, 0);
            tblMain.Controls.Add(btnCreateCookbook, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(754, 250);
            tblMain.TabIndex = 0;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(20, 108);
            lstUserName.Margin = new Padding(20, 3, 20, 3);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(337, 33);
            lstUserName.TabIndex = 0;
            // 
            // btnCreateCookbook
            // 
            btnCreateCookbook.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCreateCookbook.AutoSize = true;
            btnCreateCookbook.Location = new Point(397, 107);
            btnCreateCookbook.Margin = new Padding(20, 3, 20, 3);
            btnCreateCookbook.Name = "btnCreateCookbook";
            btnCreateCookbook.Size = new Size(337, 35);
            btnCreateCookbook.TabIndex = 1;
            btnCreateCookbook.Text = " Create Cookbook";
            btnCreateCookbook.UseVisualStyleBackColor = true;
            // 
            // frmCookbookAutoCreate
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 250);
            Controls.Add(tblMain);
            Name = "frmCookbookAutoCreate";
            Text = "Auto-Create A Cookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstUserName;
        private Button btnCreateCookbook;
    }
}