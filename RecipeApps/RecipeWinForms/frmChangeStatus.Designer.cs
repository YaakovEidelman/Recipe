namespace RecipeWinForms
{
    partial class frmChangeStatus
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
            lblRecipeName = new Label();
            tblDates = new TableLayoutPanel();
            lblStatusDates = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            tblCurrentStatus = new TableLayoutPanel();
            lblCurrentStatusLabel = new Label();
            lblRecipeStatus = new Label();
            tblButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            lblDateDrafted = new Label();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            tblMain.SuspendLayout();
            tblDates.SuspendLayout();
            tblCurrentStatus.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(tblDates, 0, 2);
            tblMain.Controls.Add(tblCurrentStatus, 0, 1);
            tblMain.Controls.Add(tblButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecipeName.Location = new Point(3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(794, 112);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 5;
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblDates.Controls.Add(lblDateArchived, 3, 1);
            tblDates.Controls.Add(lblStatusDates, 0, 1);
            tblDates.Controls.Add(lblDrafted, 1, 0);
            tblDates.Controls.Add(lblPublished, 2, 0);
            tblDates.Controls.Add(lblArchived, 3, 0);
            tblDates.Controls.Add(lblDateDrafted, 1, 1);
            tblDates.Controls.Add(lblDatePublished, 2, 1);
            tblDates.Dock = DockStyle.Fill;
            tblDates.Location = new Point(3, 227);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 2;
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.Size = new Size(794, 106);
            tblDates.TabIndex = 2;
            // 
            // lblStatusDates
            // 
            lblStatusDates.Anchor = AnchorStyles.Left;
            lblStatusDates.AutoSize = true;
            lblStatusDates.Location = new Point(3, 67);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(110, 25);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(161, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(152, 53);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(319, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(152, 53);
            lblPublished.TabIndex = 2;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(477, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(152, 53);
            lblArchived.TabIndex = 4;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblCurrentStatus
            // 
            tblCurrentStatus.ColumnCount = 2;
            tblCurrentStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCurrentStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCurrentStatus.Controls.Add(lblCurrentStatusLabel, 0, 0);
            tblCurrentStatus.Controls.Add(lblRecipeStatus, 1, 0);
            tblCurrentStatus.Dock = DockStyle.Fill;
            tblCurrentStatus.Location = new Point(3, 115);
            tblCurrentStatus.Name = "tblCurrentStatus";
            tblCurrentStatus.RowCount = 1;
            tblCurrentStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCurrentStatus.Size = new Size(794, 106);
            tblCurrentStatus.TabIndex = 2;
            // 
            // lblCurrentStatusLabel
            // 
            lblCurrentStatusLabel.Anchor = AnchorStyles.Right;
            lblCurrentStatusLabel.AutoSize = true;
            lblCurrentStatusLabel.Location = new Point(267, 40);
            lblCurrentStatusLabel.Name = "lblCurrentStatusLabel";
            lblCurrentStatusLabel.Size = new Size(127, 25);
            lblCurrentStatusLabel.TabIndex = 0;
            lblCurrentStatusLabel.Text = "Current Status:";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecipeStatus.Location = new Point(400, 40);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(95, 25);
            lblRecipeStatus.TabIndex = 1;
            lblRecipeStatus.Text = "No Status";
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.Controls.Add(btnDraft, 0, 0);
            tblButtons.Controls.Add(btnPublish, 1, 0);
            tblButtons.Controls.Add(btnArchive, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 339);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(794, 108);
            tblButtons.TabIndex = 3;
            // 
            // btnDraft
            // 
            btnDraft.Dock = DockStyle.Fill;
            btnDraft.Location = new Point(3, 3);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(258, 102);
            btnDraft.TabIndex = 0;
            btnDraft.Tag = "Drafted";
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.Dock = DockStyle.Fill;
            btnPublish.Location = new Point(267, 3);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(258, 102);
            btnPublish.TabIndex = 1;
            btnPublish.Tag = "Published";
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.Dock = DockStyle.Fill;
            btnArchive.Location = new Point(531, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(260, 102);
            btnArchive.TabIndex = 2;
            btnArchive.Tag = "Archived";
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Dock = DockStyle.Fill;
            lblDateDrafted.Location = new Point(161, 53);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(152, 53);
            lblDateDrafted.TabIndex = 6;
            lblDateDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Location = new Point(319, 53);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(152, 53);
            lblDatePublished.TabIndex = 7;
            lblDatePublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Location = new Point(477, 53);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(152, 53);
            lblDateArchived.TabIndex = 10;
            lblDateArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmChangeStatus
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmChangeStatus";
            Text = "Change Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblDates.ResumeLayout(false);
            tblDates.PerformLayout();
            tblCurrentStatus.ResumeLayout(false);
            tblCurrentStatus.PerformLayout();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TableLayoutPanel tblDates;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TableLayoutPanel tblCurrentStatus;
        private Label lblCurrentStatusLabel;
        private Label lblRecipeStatus;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
        private Label lblDateDrafted;
        private Label lblDateArchived;
        private Label lblDatePublished;
    }
}