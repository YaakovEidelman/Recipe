namespace RecipeWinForms
{
    partial class frmMealList
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
            gMealsList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gMealsList).BeginInit();
            SuspendLayout();
            // 
            // gMealsList
            // 
            gMealsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gMealsList.Dock = DockStyle.Fill;
            gMealsList.Location = new Point(0, 0);
            gMealsList.Name = "gMealsList";
            gMealsList.RowHeadersWidth = 62;
            gMealsList.RowTemplate.Height = 33;
            gMealsList.Size = new Size(953, 559);
            gMealsList.StandardTab = true;
            gMealsList.TabIndex = 0;
            // 
            // frmMealList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 559);
            Controls.Add(gMealsList);
            Name = "frmMealList";
            Text = "Meal List";
            ((System.ComponentModel.ISupportInitialize)gMealsList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gMealsList;
    }
}