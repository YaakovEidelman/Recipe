namespace RecipeWinForms
{
    partial class frmRecipe
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
            tblRecipeMain = new TableLayoutPanel();
            lblRecipeName = new Label();
            lblCalories = new Label();
            lblRecipeStatus = new Label();
            lblDateDrafted = new Label();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            txtRecipeStatus = new TextBox();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            lblStaffId = new Label();
            lblCuisineId = new Label();
            lstUserName = new ComboBox();
            lstCuisineType = new ComboBox();
            tblButtons = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            tblRecipeMain.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblRecipeMain
            // 
            tblRecipeMain.AutoSize = true;
            tblRecipeMain.ColumnCount = 2;
            tblRecipeMain.ColumnStyles.Add(new ColumnStyle());
            tblRecipeMain.ColumnStyles.Add(new ColumnStyle());
            tblRecipeMain.Controls.Add(lblRecipeName, 0, 2);
            tblRecipeMain.Controls.Add(lblCalories, 0, 3);
            tblRecipeMain.Controls.Add(lblRecipeStatus, 0, 4);
            tblRecipeMain.Controls.Add(lblDateDrafted, 0, 5);
            tblRecipeMain.Controls.Add(lblDatePublished, 0, 6);
            tblRecipeMain.Controls.Add(lblDateArchived, 0, 7);
            tblRecipeMain.Controls.Add(txtRecipeName, 1, 2);
            tblRecipeMain.Controls.Add(txtCalories, 1, 3);
            tblRecipeMain.Controls.Add(txtRecipeStatus, 1, 4);
            tblRecipeMain.Controls.Add(txtDateDrafted, 1, 5);
            tblRecipeMain.Controls.Add(txtDatePublished, 1, 6);
            tblRecipeMain.Controls.Add(txtDateArchived, 1, 7);
            tblRecipeMain.Controls.Add(lblStaffId, 0, 0);
            tblRecipeMain.Controls.Add(lblCuisineId, 0, 1);
            tblRecipeMain.Controls.Add(lstUserName, 1, 0);
            tblRecipeMain.Controls.Add(lstCuisineType, 1, 1);
            tblRecipeMain.Dock = DockStyle.Fill;
            tblRecipeMain.Location = new Point(0, 0);
            tblRecipeMain.Name = "tblRecipeMain";
            tblRecipeMain.RowCount = 8;
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.Size = new Size(486, 399);
            tblRecipeMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 84);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(119, 25);
            lblRecipeName.TabIndex = 2;
            lblRecipeName.Text = "Recipe Name:";
            lblRecipeName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 121);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(78, 25);
            lblCalories.TabIndex = 3;
            lblCalories.Text = "Calories:";
            lblCalories.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 158);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(120, 25);
            lblRecipeStatus.TabIndex = 4;
            lblRecipeStatus.Text = "Recipe Status:";
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.Anchor = AnchorStyles.Left;
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Location = new Point(3, 195);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(118, 25);
            lblDateDrafted.TabIndex = 5;
            lblDateDrafted.Text = "Date Drafted:";
            lblDateDrafted.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Location = new Point(3, 232);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(135, 25);
            lblDatePublished.TabIndex = 6;
            lblDatePublished.Text = "Date Published:";
            lblDatePublished.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.Location = new Point(3, 263);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(127, 25);
            lblDateArchived.TabIndex = 7;
            lblDateArchived.Text = "Date Archived:";
            lblDateArchived.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(144, 81);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(339, 31);
            txtRecipeName.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(144, 118);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(339, 31);
            txtCalories.TabIndex = 11;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(144, 155);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(339, 31);
            txtRecipeStatus.TabIndex = 12;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Dock = DockStyle.Fill;
            txtDateDrafted.Location = new Point(144, 192);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(339, 31);
            txtDateDrafted.TabIndex = 13;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(144, 229);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(339, 31);
            txtDatePublished.TabIndex = 14;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(144, 266);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(339, 31);
            txtDateArchived.TabIndex = 15;
            // 
            // lblStaffId
            // 
            lblStaffId.Anchor = AnchorStyles.Left;
            lblStaffId.AutoSize = true;
            lblStaffId.Location = new Point(3, 7);
            lblStaffId.Name = "lblStaffId";
            lblStaffId.Size = new Size(104, 25);
            lblStaffId.TabIndex = 0;
            lblStaffId.Text = "Chef Name:";
            lblStaffId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCuisineId
            // 
            lblCuisineId.Anchor = AnchorStyles.Left;
            lblCuisineId.AutoSize = true;
            lblCuisineId.Location = new Point(3, 46);
            lblCuisineId.Name = "lblCuisineId";
            lblCuisineId.Size = new Size(114, 25);
            lblCuisineId.TabIndex = 1;
            lblCuisineId.Text = "Cuisine Type:";
            lblCuisineId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lstUserName
            // 
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(144, 3);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(182, 33);
            lstUserName.TabIndex = 8;
            // 
            // lstCuisineType
            // 
            lstCuisineType.FormattingEnabled = true;
            lstCuisineType.Location = new Point(144, 42);
            lstCuisineType.Name = "lstCuisineType";
            lstCuisineType.Size = new Size(182, 33);
            lstCuisineType.TabIndex = 9;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnSave, 0, 0);
            tblButtons.Controls.Add(btnDelete, 1, 0);
            tblButtons.Dock = DockStyle.Bottom;
            tblButtons.Location = new Point(0, 345);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle());
            tblButtons.Size = new Size(486, 54);
            tblButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(237, 48);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(246, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(237, 48);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 399);
            Controls.Add(tblButtons);
            Controls.Add(tblRecipeMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblRecipeMain.ResumeLayout(false);
            tblRecipeMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblRecipeMain;
        private Label lblRecipeName;
        private Label lblCalories;
        private Label lblRecipeStatus;
        private Label lblDateDrafted;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtRecipeStatus;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnDelete;
        private Label lblStaffId;
        private Label lblCuisineId;
        private ComboBox lstUserName;
        private ComboBox lstCuisineType;
    }
}