namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            flpOptions = new FlowLayoutPanel();
            optStaff = new RadioButton();
            optCuisine = new RadioButton();
            optIngredient = new RadioButton();
            optMeasurement = new RadioButton();
            optCourse = new RadioButton();
            gData = new DataGridView();
            btnSave = new Button();
            tblMain.SuspendLayout();
            flpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(flpOptions, 0, 0);
            tblMain.Controls.Add(gData, 1, 0);
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(945, 615);
            tblMain.TabIndex = 0;
            // 
            // flpOptions
            // 
            flpOptions.Controls.Add(optStaff);
            flpOptions.Controls.Add(optCuisine);
            flpOptions.Controls.Add(optIngredient);
            flpOptions.Controls.Add(optMeasurement);
            flpOptions.Controls.Add(optCourse);
            flpOptions.Dock = DockStyle.Fill;
            flpOptions.FlowDirection = FlowDirection.TopDown;
            flpOptions.Location = new Point(3, 3);
            flpOptions.Name = "flpOptions";
            flpOptions.Padding = new Padding(0, 5, 0, 5);
            tblMain.SetRowSpan(flpOptions, 2);
            flpOptions.Size = new Size(206, 609);
            flpOptions.TabIndex = 0;
            // 
            // optStaff
            // 
            optStaff.AutoSize = true;
            optStaff.Location = new Point(10, 8);
            optStaff.Margin = new Padding(10, 3, 3, 3);
            optStaff.Name = "optStaff";
            optStaff.Padding = new Padding(10, 10, 0, 10);
            optStaff.Size = new Size(90, 49);
            optStaff.TabIndex = 0;
            optStaff.TabStop = true;
            optStaff.Text = "Users";
            optStaff.UseVisualStyleBackColor = true;
            // 
            // optCuisine
            // 
            optCuisine.AutoSize = true;
            optCuisine.Location = new Point(10, 63);
            optCuisine.Margin = new Padding(10, 3, 3, 3);
            optCuisine.Name = "optCuisine";
            optCuisine.Padding = new Padding(10, 10, 0, 10);
            optCuisine.Size = new Size(111, 49);
            optCuisine.TabIndex = 1;
            optCuisine.TabStop = true;
            optCuisine.Text = "Cuisines";
            optCuisine.UseVisualStyleBackColor = true;
            // 
            // optIngredient
            // 
            optIngredient.AutoSize = true;
            optIngredient.Location = new Point(10, 118);
            optIngredient.Margin = new Padding(10, 3, 3, 3);
            optIngredient.Name = "optIngredient";
            optIngredient.Padding = new Padding(10, 10, 0, 10);
            optIngredient.Size = new Size(136, 49);
            optIngredient.TabIndex = 2;
            optIngredient.TabStop = true;
            optIngredient.Text = "Ingredients";
            optIngredient.UseVisualStyleBackColor = true;
            // 
            // optMeasurement
            // 
            optMeasurement.AutoSize = true;
            optMeasurement.Location = new Point(10, 173);
            optMeasurement.Margin = new Padding(10, 3, 3, 3);
            optMeasurement.Name = "optMeasurement";
            optMeasurement.Padding = new Padding(10, 10, 0, 10);
            optMeasurement.Size = new Size(163, 49);
            optMeasurement.TabIndex = 3;
            optMeasurement.TabStop = true;
            optMeasurement.Text = "Measurements";
            optMeasurement.UseVisualStyleBackColor = true;
            // 
            // optCourse
            // 
            optCourse.AutoSize = true;
            optCourse.Location = new Point(10, 228);
            optCourse.Margin = new Padding(10, 3, 3, 3);
            optCourse.Name = "optCourse";
            optCourse.Padding = new Padding(10, 10, 0, 10);
            optCourse.Size = new Size(110, 49);
            optCourse.TabIndex = 4;
            optCourse.TabStop = true;
            optCourse.Text = "Courses";
            optCourse.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(215, 3);
            gData.Name = "gData";
            gData.RowHeadersWidth = 62;
            gData.RowTemplate.Height = 33;
            gData.Size = new Size(727, 569);
            gData.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(830, 578);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 615);
            Controls.Add(tblMain);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            flpOptions.ResumeLayout(false);
            flpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private FlowLayoutPanel flpOptions;
        private RadioButton optStaff;
        private RadioButton optCuisine;
        private RadioButton optIngredient;
        private RadioButton optMeasurement;
        private RadioButton optCourse;
        private DataGridView gData;
        private Button btnSave;
    }
}