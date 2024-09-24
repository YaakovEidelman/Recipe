namespace RecipeWinForms
{
    partial class frmCookbook
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
            tblCookbookInfo = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblCookbookName = new Label();
            txtCookbookName = new TextBox();
            lblUserName = new Label();
            lstUserName = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            tblDateCreated = new TableLayoutPanel();
            lblDateCreated = new Label();
            txtDateCreated = new TextBox();
            lblActive = new Label();
            chkIsActive = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSaveRecipes = new Button();
            gCookbookRecipes = new DataGridView();
            tblMain.SuspendLayout();
            tblCookbookInfo.SuspendLayout();
            tblDateCreated.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(tblCookbookInfo, 0, 0);
            tblMain.Controls.Add(tableLayoutPanel1, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(859, 831);
            tblMain.TabIndex = 0;
            // 
            // tblCookbookInfo
            // 
            tblCookbookInfo.ColumnCount = 3;
            tblCookbookInfo.ColumnStyles.Add(new ColumnStyle());
            tblCookbookInfo.ColumnStyles.Add(new ColumnStyle());
            tblCookbookInfo.ColumnStyles.Add(new ColumnStyle());
            tblCookbookInfo.Controls.Add(btnSave, 0, 0);
            tblCookbookInfo.Controls.Add(btnDelete, 1, 0);
            tblCookbookInfo.Controls.Add(lblCookbookName, 0, 1);
            tblCookbookInfo.Controls.Add(txtCookbookName, 1, 1);
            tblCookbookInfo.Controls.Add(lblUserName, 0, 2);
            tblCookbookInfo.Controls.Add(lstUserName, 1, 2);
            tblCookbookInfo.Controls.Add(lblPrice, 0, 3);
            tblCookbookInfo.Controls.Add(txtPrice, 1, 3);
            tblCookbookInfo.Controls.Add(tblDateCreated, 2, 3);
            tblCookbookInfo.Controls.Add(lblActive, 0, 4);
            tblCookbookInfo.Controls.Add(chkIsActive, 1, 4);
            tblCookbookInfo.Dock = DockStyle.Fill;
            tblCookbookInfo.Location = new Point(3, 3);
            tblCookbookInfo.Name = "tblCookbookInfo";
            tblCookbookInfo.RowCount = 5;
            tblCookbookInfo.RowStyles.Add(new RowStyle());
            tblCookbookInfo.RowStyles.Add(new RowStyle());
            tblCookbookInfo.RowStyles.Add(new RowStyle());
            tblCookbookInfo.RowStyles.Add(new RowStyle());
            tblCookbookInfo.RowStyles.Add(new RowStyle());
            tblCookbookInfo.Size = new Size(853, 234);
            tblCookbookInfo.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(157, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCookbookName
            // 
            lblCookbookName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCookbookName.AutoSize = true;
            lblCookbookName.Location = new Point(3, 52);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(148, 25);
            lblCookbookName.TabIndex = 2;
            lblCookbookName.Text = "Cookbook Name";
            lblCookbookName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCookbookName
            // 
            txtCookbookName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblCookbookInfo.SetColumnSpan(txtCookbookName, 2);
            txtCookbookName.Location = new Point(157, 43);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(693, 31);
            txtCookbookName.TabIndex = 3;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 91);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(47, 25);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "User";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblCookbookInfo.SetColumnSpan(lstUserName, 2);
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(157, 80);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(693, 33);
            lstUserName.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(3, 164);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Location = new Point(157, 155);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(278, 31);
            txtPrice.TabIndex = 7;
            // 
            // tblDateCreated
            // 
            tblDateCreated.ColumnCount = 1;
            tblDateCreated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDateCreated.Controls.Add(lblDateCreated, 0, 0);
            tblDateCreated.Controls.Add(txtDateCreated, 0, 1);
            tblDateCreated.Dock = DockStyle.Fill;
            tblDateCreated.Location = new Point(441, 119);
            tblDateCreated.Name = "tblDateCreated";
            tblDateCreated.RowCount = 2;
            tblDateCreated.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDateCreated.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDateCreated.Size = new Size(409, 67);
            tblDateCreated.TabIndex = 8;
            // 
            // lblDateCreated
            // 
            lblDateCreated.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDateCreated.AutoSize = true;
            lblDateCreated.Location = new Point(3, 4);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(403, 25);
            lblDateCreated.TabIndex = 0;
            lblDateCreated.Text = "Date Created:";
            lblDateCreated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDateCreated
            // 
            txtDateCreated.Dock = DockStyle.Fill;
            txtDateCreated.Enabled = false;
            txtDateCreated.Location = new Point(3, 36);
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.Size = new Size(403, 31);
            txtDateCreated.TabIndex = 1;
            // 
            // lblActive
            // 
            lblActive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblActive.AutoSize = true;
            lblActive.Location = new Point(3, 209);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(60, 25);
            lblActive.TabIndex = 9;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkIsActive
            // 
            chkIsActive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(157, 210);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(22, 21);
            chkIsActive.TabIndex = 10;
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnSaveRecipes, 0, 0);
            tableLayoutPanel1.Controls.Add(gCookbookRecipes, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 243);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(853, 585);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSaveRecipes
            // 
            btnSaveRecipes.AutoSize = true;
            btnSaveRecipes.Location = new Point(3, 3);
            btnSaveRecipes.Name = "btnSaveRecipes";
            btnSaveRecipes.Size = new Size(112, 35);
            btnSaveRecipes.TabIndex = 0;
            btnSaveRecipes.Text = "Save";
            btnSaveRecipes.UseVisualStyleBackColor = true;
            // 
            // gCookbookRecipes
            // 
            gCookbookRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookRecipes.Dock = DockStyle.Fill;
            gCookbookRecipes.Location = new Point(3, 44);
            gCookbookRecipes.Name = "gCookbookRecipes";
            gCookbookRecipes.RowHeadersWidth = 62;
            gCookbookRecipes.RowTemplate.Height = 33;
            gCookbookRecipes.Size = new Size(847, 538);
            gCookbookRecipes.StandardTab = true;
            gCookbookRecipes.TabIndex = 1;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 831);
            Controls.Add(tblMain);
            Name = "frmCookbook";
            Text = "Cookbook";
            tblMain.ResumeLayout(false);
            tblCookbookInfo.ResumeLayout(false);
            tblCookbookInfo.PerformLayout();
            tblDateCreated.ResumeLayout(false);
            tblDateCreated.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblCookbookInfo;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbookName;
        private TextBox txtCookbookName;
        private Label lblUserName;
        private ComboBox lstUserName;
        private Label lblPrice;
        private TextBox txtPrice;
        private TableLayoutPanel tblDateCreated;
        private Label lblDateCreated;
        private TextBox txtDateCreated;
        private Label lblActive;
        private CheckBox chkIsActive;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSaveRecipes;
        private DataGridView gCookbookRecipes;
    }
}