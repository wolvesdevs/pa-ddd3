namespace DDDNET8.UI.Views
{
    partial class WeatherListView
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
            WeathersDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)WeathersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // WeathersDataGrid
            // 
            WeathersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WeathersDataGrid.Dock = DockStyle.Fill;
            WeathersDataGrid.Location = new Point(0, 0);
            WeathersDataGrid.Name = "WeathersDataGrid";
            WeathersDataGrid.RowHeadersWidth = 62;
            WeathersDataGrid.Size = new Size(1107, 475);
            WeathersDataGrid.TabIndex = 0;
            // 
            // WeatherListView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 475);
            Controls.Add(WeathersDataGrid);
            Name = "WeatherListView";
            Text = "WeatherListView";
            ((System.ComponentModel.ISupportInitialize)WeathersDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView WeathersDataGrid;
    }
}