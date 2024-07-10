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
            tblRecipeMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblRecipeMain
            // 
            tblRecipeMain.AutoSize = true;
            tblRecipeMain.ColumnCount = 2;
            tblRecipeMain.ColumnStyles.Add(new ColumnStyle());
            tblRecipeMain.ColumnStyles.Add(new ColumnStyle());
            tblRecipeMain.Controls.Add(lblRecipeName, 0, 0);
            tblRecipeMain.Controls.Add(lblCalories, 0, 1);
            tblRecipeMain.Controls.Add(lblRecipeStatus, 0, 2);
            tblRecipeMain.Controls.Add(lblDateDrafted, 0, 3);
            tblRecipeMain.Controls.Add(lblDatePublished, 0, 4);
            tblRecipeMain.Controls.Add(lblDateArchived, 0, 5);
            tblRecipeMain.Controls.Add(txtRecipeName, 1, 0);
            tblRecipeMain.Controls.Add(txtCalories, 1, 1);
            tblRecipeMain.Controls.Add(txtRecipeStatus, 1, 2);
            tblRecipeMain.Controls.Add(txtDateDrafted, 1, 3);
            tblRecipeMain.Controls.Add(txtDatePublished, 1, 4);
            tblRecipeMain.Controls.Add(txtDateArchived, 1, 5);
            tblRecipeMain.Dock = DockStyle.Fill;
            tblRecipeMain.Location = new Point(0, 0);
            tblRecipeMain.Name = "tblRecipeMain";
            tblRecipeMain.RowCount = 6;
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.RowStyles.Add(new RowStyle());
            tblRecipeMain.Size = new Size(429, 254);
            tblRecipeMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Location = new Point(3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(135, 37);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name:";
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.Dock = DockStyle.Fill;
            lblCalories.Location = new Point(3, 37);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(135, 37);
            lblCalories.TabIndex = 1;
            lblCalories.Text = "Calories:";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Dock = DockStyle.Fill;
            lblRecipeStatus.Location = new Point(3, 74);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(135, 37);
            lblRecipeStatus.TabIndex = 2;
            lblRecipeStatus.Text = "Recipe Status:";
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Dock = DockStyle.Fill;
            lblDateDrafted.Location = new Point(3, 111);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(135, 37);
            lblDateDrafted.TabIndex = 3;
            lblDateDrafted.Text = "Date Drafted:";
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Location = new Point(3, 148);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(135, 37);
            lblDatePublished.TabIndex = 4;
            lblDatePublished.Text = "Date Published:";
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Location = new Point(3, 185);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(135, 69);
            lblDateArchived.TabIndex = 5;
            lblDateArchived.Text = "Date Archived:";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(144, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(282, 31);
            txtRecipeName.TabIndex = 6;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(144, 40);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(282, 31);
            txtCalories.TabIndex = 7;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(144, 77);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(282, 31);
            txtRecipeStatus.TabIndex = 8;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Dock = DockStyle.Fill;
            txtDateDrafted.Location = new Point(144, 114);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(282, 31);
            txtDateDrafted.TabIndex = 9;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(144, 151);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(282, 31);
            txtDatePublished.TabIndex = 10;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(144, 188);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(282, 31);
            txtDateArchived.TabIndex = 11;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 254);
            Controls.Add(tblRecipeMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblRecipeMain.ResumeLayout(false);
            tblRecipeMain.PerformLayout();
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
    }
}