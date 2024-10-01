namespace RecipeWinForms
{
    partial class frmRecipeUpdated
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
            flpSaveDeleteBtns = new FlowLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            btnChangeStatus = new Button();
            lblRecipeName = new Label();
            txtRecipeName = new TextBox();
            lblUser = new Label();
            lstUserName = new ComboBox();
            lblCuisine = new Label();
            lstCuisineType = new ComboBox();
            lblNumCalories = new Label();
            txtCalories = new TextBox();
            lblCurrentStatus = new Label();
            lblStatusDates = new Label();
            tblStatusDates = new TableLayoutPanel();
            flpDrafted = new FlowLayoutPanel();
            lblDrafted = new Label();
            lblDateDrafted = new Label();
            flpPublished = new FlowLayoutPanel();
            lblPublished = new Label();
            lblDatePublished = new Label();
            flpArchived = new FlowLayoutPanel();
            lblArchived = new Label();
            lblDateArchived = new Label();
            tpRecipeInfo = new TabControl();
            tabIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnIngredientSave = new Button();
            gIngredients = new DataGridView();
            tabSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnStepsSave = new Button();
            gSteps = new DataGridView();
            lblRecipeStatus = new Label();
            tblMain.SuspendLayout();
            flpSaveDeleteBtns.SuspendLayout();
            tblStatusDates.SuspendLayout();
            flpDrafted.SuspendLayout();
            flpPublished.SuspendLayout();
            flpArchived.SuspendLayout();
            tpRecipeInfo.SuspendLayout();
            tabIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tabSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(flpSaveDeleteBtns, 0, 0);
            tblMain.Controls.Add(btnChangeStatus, 1, 0);
            tblMain.Controls.Add(lblRecipeName, 0, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lblUser, 0, 2);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(lblCuisine, 0, 3);
            tblMain.Controls.Add(lstCuisineType, 1, 3);
            tblMain.Controls.Add(lblNumCalories, 0, 4);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lblCurrentStatus, 0, 5);
            tblMain.Controls.Add(lblStatusDates, 0, 6);
            tblMain.Controls.Add(tblStatusDates, 1, 6);
            tblMain.Controls.Add(tpRecipeInfo, 0, 7);
            tblMain.Controls.Add(lblRecipeStatus, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(760, 774);
            tblMain.TabIndex = 0;
            // 
            // flpSaveDeleteBtns
            // 
            flpSaveDeleteBtns.AutoSize = true;
            flpSaveDeleteBtns.Controls.Add(btnSave);
            flpSaveDeleteBtns.Controls.Add(btnDelete);
            flpSaveDeleteBtns.Location = new Point(3, 3);
            flpSaveDeleteBtns.Name = "flpSaveDeleteBtns";
            flpSaveDeleteBtns.Size = new Size(118, 80);
            flpSaveDeleteBtns.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(3, 43);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Dock = DockStyle.Right;
            btnChangeStatus.Location = new Point(610, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(147, 80);
            btnChangeStatus.TabIndex = 1;
            btnChangeStatus.Text = "Change Status...";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 92);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(115, 25);
            lblRecipeName.TabIndex = 2;
            lblRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(132, 89);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(625, 31);
            txtRecipeName.TabIndex = 3;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 130);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(47, 25);
            lblUser.TabIndex = 4;
            lblUser.Text = "User";
            // 
            // lstUserName
            // 
            lstUserName.Dock = DockStyle.Fill;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(132, 126);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(625, 33);
            lstUserName.TabIndex = 5;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 169);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(68, 25);
            lblCuisine.TabIndex = 6;
            lblCuisine.Text = "Cuisine";
            // 
            // lstCuisineType
            // 
            lstCuisineType.Dock = DockStyle.Fill;
            lstCuisineType.FormattingEnabled = true;
            lstCuisineType.Location = new Point(132, 165);
            lstCuisineType.Name = "lstCuisineType";
            lstCuisineType.Size = new Size(625, 33);
            lstCuisineType.TabIndex = 7;
            // 
            // lblNumCalories
            // 
            lblNumCalories.Anchor = AnchorStyles.Left;
            lblNumCalories.AutoSize = true;
            lblNumCalories.Location = new Point(3, 207);
            lblNumCalories.Name = "lblNumCalories";
            lblNumCalories.Size = new Size(118, 25);
            lblNumCalories.TabIndex = 8;
            lblNumCalories.Text = "Num Calories";
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(132, 204);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(625, 31);
            txtCalories.TabIndex = 9;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.Anchor = AnchorStyles.Left;
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Location = new Point(3, 238);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(123, 25);
            lblCurrentStatus.TabIndex = 10;
            lblCurrentStatus.Text = "Current Status";
            // 
            // lblStatusDates
            // 
            lblStatusDates.Anchor = AnchorStyles.Left;
            lblStatusDates.AutoSize = true;
            lblStatusDates.Location = new Point(3, 287);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(110, 25);
            lblStatusDates.TabIndex = 12;
            lblStatusDates.Text = "Status Dates";
            // 
            // tblStatusDates
            // 
            tblStatusDates.ColumnCount = 3;
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.Controls.Add(flpDrafted, 0, 0);
            tblStatusDates.Controls.Add(flpPublished, 1, 0);
            tblStatusDates.Controls.Add(flpArchived, 2, 0);
            tblStatusDates.Dock = DockStyle.Fill;
            tblStatusDates.Location = new Point(132, 266);
            tblStatusDates.Name = "tblStatusDates";
            tblStatusDates.RowCount = 1;
            tblStatusDates.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatusDates.Size = new Size(625, 68);
            tblStatusDates.TabIndex = 12;
            // 
            // flpDrafted
            // 
            flpDrafted.Controls.Add(lblDrafted);
            flpDrafted.Controls.Add(lblDateDrafted);
            flpDrafted.Dock = DockStyle.Fill;
            flpDrafted.FlowDirection = FlowDirection.TopDown;
            flpDrafted.Location = new Point(3, 3);
            flpDrafted.Name = "flpDrafted";
            flpDrafted.Size = new Size(202, 62);
            flpDrafted.TabIndex = 0;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(72, 25);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Dock = DockStyle.Fill;
            lblDateDrafted.Location = new Point(3, 25);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(72, 25);
            lblDateDrafted.TabIndex = 1;
            // 
            // flpPublished
            // 
            flpPublished.Controls.Add(lblPublished);
            flpPublished.Controls.Add(lblDatePublished);
            flpPublished.Dock = DockStyle.Fill;
            flpPublished.FlowDirection = FlowDirection.TopDown;
            flpPublished.Location = new Point(211, 3);
            flpPublished.Name = "flpPublished";
            flpPublished.Size = new Size(202, 62);
            flpPublished.TabIndex = 1;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(3, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(89, 25);
            lblPublished.TabIndex = 0;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Location = new Point(3, 25);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(89, 25);
            lblDatePublished.TabIndex = 2;
            // 
            // flpArchived
            // 
            flpArchived.Controls.Add(lblArchived);
            flpArchived.Controls.Add(lblDateArchived);
            flpArchived.Dock = DockStyle.Fill;
            flpArchived.FlowDirection = FlowDirection.TopDown;
            flpArchived.Location = new Point(419, 3);
            flpArchived.Name = "flpArchived";
            flpArchived.Size = new Size(203, 62);
            flpArchived.TabIndex = 2;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(3, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(81, 25);
            lblArchived.TabIndex = 0;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Location = new Point(3, 25);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(81, 25);
            lblDateArchived.TabIndex = 2;
            // 
            // tpRecipeInfo
            // 
            tblMain.SetColumnSpan(tpRecipeInfo, 2);
            tpRecipeInfo.Controls.Add(tabIngredients);
            tpRecipeInfo.Controls.Add(tabSteps);
            tpRecipeInfo.Dock = DockStyle.Fill;
            tpRecipeInfo.Location = new Point(3, 340);
            tpRecipeInfo.Name = "tpRecipeInfo";
            tpRecipeInfo.SelectedIndex = 0;
            tpRecipeInfo.Size = new Size(754, 431);
            tpRecipeInfo.TabIndex = 13;
            // 
            // tabIngredients
            // 
            tabIngredients.Controls.Add(tblIngredients);
            tabIngredients.Location = new Point(4, 34);
            tabIngredients.Name = "tabIngredients";
            tabIngredients.Padding = new Padding(3);
            tabIngredients.Size = new Size(746, 393);
            tabIngredients.TabIndex = 0;
            tabIngredients.Text = "Ingredients";
            tabIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle());
            tblIngredients.Controls.Add(btnIngredientSave, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIngredients.Size = new Size(740, 387);
            tblIngredients.TabIndex = 0;
            // 
            // btnIngredientSave
            // 
            btnIngredientSave.Location = new Point(3, 3);
            btnIngredientSave.Name = "btnIngredientSave";
            btnIngredientSave.Size = new Size(112, 34);
            btnIngredientSave.TabIndex = 0;
            btnIngredientSave.Text = "Save";
            btnIngredientSave.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 43);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 62;
            gIngredients.RowTemplate.Height = 33;
            gIngredients.Size = new Size(734, 341);
            gIngredients.TabIndex = 1;
            // 
            // tabSteps
            // 
            tabSteps.Controls.Add(tblSteps);
            tabSteps.Location = new Point(4, 34);
            tabSteps.Name = "tabSteps";
            tabSteps.Padding = new Padding(3);
            tabSteps.Size = new Size(746, 393);
            tabSteps.TabIndex = 1;
            tabSteps.Text = "Steps";
            tabSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle());
            tblSteps.Controls.Add(btnStepsSave, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 50.9333344F));
            tblSteps.Size = new Size(740, 387);
            tblSteps.TabIndex = 0;
            // 
            // btnStepsSave
            // 
            btnStepsSave.Location = new Point(3, 3);
            btnStepsSave.Name = "btnStepsSave";
            btnStepsSave.Size = new Size(112, 34);
            btnStepsSave.TabIndex = 0;
            btnStepsSave.Text = "Save";
            btnStepsSave.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 43);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 62;
            gSteps.RowTemplate.Height = 33;
            gSteps.Size = new Size(734, 341);
            gSteps.TabIndex = 1;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Dock = DockStyle.Fill;
            lblRecipeStatus.Location = new Point(132, 238);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(625, 25);
            lblRecipeStatus.TabIndex = 14;
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmRecipeUpdated
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 774);
            Controls.Add(tblMain);
            Name = "frmRecipeUpdated";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            flpSaveDeleteBtns.ResumeLayout(false);
            tblStatusDates.ResumeLayout(false);
            flpDrafted.ResumeLayout(false);
            flpDrafted.PerformLayout();
            flpPublished.ResumeLayout(false);
            flpPublished.PerformLayout();
            flpArchived.ResumeLayout(false);
            flpArchived.PerformLayout();
            tpRecipeInfo.ResumeLayout(false);
            tabIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tabSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TextBox txtRecipeName;
        private Label lblUser;
        private ComboBox lstUserName;
        private Label lblCuisine;
        private ComboBox lstCuisineType;
        private Label lblNumCalories;
        private TextBox txtCalories;
        private Label lblCurrentStatus;
        private Label lblStatusDates;
        private TableLayoutPanel tblStatusDates;
        private TabControl tpRecipeInfo;
        private TabPage tabIngredients;
        private TabPage tabSteps;
        private FlowLayoutPanel flpDrafted;
        private Label lblDrafted;
        private FlowLayoutPanel flpPublished;
        private FlowLayoutPanel flpArchived;
        private Label lblPublished;
        private Label lblArchived;
        private Button btnChangeStatus;
        private FlowLayoutPanel flpSaveDeleteBtns;
        private Button btnSave;
        private Button btnDelete;
        private TableLayoutPanel tblIngredients;
        private Button btnIngredientSave;
        private DataGridView gIngredients;
        private TableLayoutPanel tblSteps;
        private Button btnStepsSave;
        private DataGridView gSteps;
        private Label lblDateDrafted;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblRecipeStatus;
    }
}