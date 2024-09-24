namespace RecipeWinForms
{
    partial class frmDashboard
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
            lblHeader = new Label();
            lblSubHeader = new Label();
            gDashboard = new DataGridView();
            tblListButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gDashboard).BeginInit();
            tblListButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.AutoSize = true;
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblHeader, 0, 0);
            tblMain.Controls.Add(lblSubHeader, 0, 1);
            tblMain.Controls.Add(gDashboard, 0, 2);
            tblMain.Controls.Add(tblListButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 27.7777786F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 27.77778F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4444427F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            tblMain.Size = new Size(1060, 750);
            tblMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1054, 178);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Hearty Hearth Desktop App";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubHeader
            // 
            lblSubHeader.AutoSize = true;
            lblSubHeader.Dock = DockStyle.Fill;
            lblSubHeader.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubHeader.Location = new Point(3, 178);
            lblSubHeader.Name = "lblSubHeader";
            lblSubHeader.Size = new Size(1054, 178);
            lblSubHeader.TabIndex = 1;
            lblSubHeader.Text = "Welcome to the Hearty Hearth desktop app. In this app you can\r\ncreate recipes and cookbooks. You can also....";
            lblSubHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gDashboard
            // 
            gDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gDashboard.Dock = DockStyle.Fill;
            gDashboard.Location = new Point(3, 359);
            gDashboard.Name = "gDashboard";
            gDashboard.RowHeadersWidth = 62;
            gDashboard.RowTemplate.Height = 33;
            gDashboard.Size = new Size(1054, 280);
            gDashboard.StandardTab = true;
            gDashboard.TabIndex = 2;
            // 
            // tblListButtons
            // 
            tblListButtons.AutoSize = true;
            tblListButtons.ColumnCount = 3;
            tblListButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblListButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblListButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblListButtons.Controls.Add(btnRecipeList, 0, 0);
            tblListButtons.Controls.Add(btnMealList, 1, 0);
            tblListButtons.Controls.Add(btnCookbookList, 2, 0);
            tblListButtons.Dock = DockStyle.Fill;
            tblListButtons.Location = new Point(3, 645);
            tblListButtons.Name = "tblListButtons";
            tblListButtons.RowCount = 1;
            tblListButtons.RowStyles.Add(new RowStyle());
            tblListButtons.Size = new Size(1054, 102);
            tblListButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Dock = DockStyle.Fill;
            btnRecipeList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRecipeList.Location = new Point(2, 2);
            btnRecipeList.Margin = new Padding(2);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(347, 98);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.Dock = DockStyle.Fill;
            btnMealList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMealList.Location = new Point(353, 2);
            btnMealList.Margin = new Padding(2);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(347, 98);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Dock = DockStyle.Fill;
            btnCookbookList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCookbookList.Location = new Point(704, 2);
            btnCookbookList.Margin = new Padding(2);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(348, 98);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 750);
            Controls.Add(tblMain);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gDashboard).EndInit();
            tblListButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblHeader;
        private Label lblSubHeader;
        private DataGridView gDashboard;
        private TableLayoutPanel tblListButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
    }
}