namespace DDDNET8.UI
{
    partial class WeatherLatestView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            DataDateLabel = new Label();
            ConditionLabel = new Label();
            TemperatureLabel = new Label();
            LatestButton = new Button();
            AreasComboBox = new ComboBox();
            ListButton = new Button();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 72);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 0;
            label1.Text = "地域";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 129);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "日時";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 186);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 2;
            label3.Text = "状態";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 241);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 3;
            label4.Text = "温度";
            // 
            // DataDateLabel
            // 
            DataDateLabel.AutoSize = true;
            DataDateLabel.Location = new Point(150, 129);
            DataDateLabel.Name = "DataDateLabel";
            DataDateLabel.Size = new Size(59, 25);
            DataDateLabel.TabIndex = 4;
            DataDateLabel.Text = "label5";
            // 
            // ConditionLabel
            // 
            ConditionLabel.AutoSize = true;
            ConditionLabel.Location = new Point(150, 186);
            ConditionLabel.Name = "ConditionLabel";
            ConditionLabel.Size = new Size(59, 25);
            ConditionLabel.TabIndex = 5;
            ConditionLabel.Text = "label6";
            // 
            // TemperatureLabel
            // 
            TemperatureLabel.AutoSize = true;
            TemperatureLabel.Location = new Point(150, 241);
            TemperatureLabel.Name = "TemperatureLabel";
            TemperatureLabel.Size = new Size(59, 25);
            TemperatureLabel.TabIndex = 6;
            TemperatureLabel.Text = "label7";
            // 
            // LatestButton
            // 
            LatestButton.Location = new Point(338, 69);
            LatestButton.Name = "LatestButton";
            LatestButton.Size = new Size(112, 34);
            LatestButton.TabIndex = 0;
            LatestButton.Text = "直近値";
            LatestButton.UseVisualStyleBackColor = true;
            LatestButton.Click += LatestButton_Click;
            // 
            // AreasComboBox
            // 
            AreasComboBox.FormattingEnabled = true;
            AreasComboBox.Location = new Point(150, 69);
            AreasComboBox.Name = "AreasComboBox";
            AreasComboBox.Size = new Size(182, 33);
            AreasComboBox.TabIndex = 2;
            // 
            // ListButton
            // 
            ListButton.Location = new Point(36, 12);
            ListButton.Name = "ListButton";
            ListButton.Size = new Size(147, 34);
            ListButton.TabIndex = 1;
            ListButton.Text = "List";
            ListButton.UseVisualStyleBackColor = true;
            ListButton.Click += ListButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(203, 12);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(147, 34);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "追加";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // WeatherLatestView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 352);
            Controls.Add(SaveButton);
            Controls.Add(ListButton);
            Controls.Add(AreasComboBox);
            Controls.Add(LatestButton);
            Controls.Add(TemperatureLabel);
            Controls.Add(ConditionLabel);
            Controls.Add(DataDateLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WeatherLatestView";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label DataDateLabel;
        private Label ConditionLabel;
        private Label TemperatureLabel;
        private Button LatestButton;
        private ComboBox AreasComboBox;
        private Button ListButton;
        private Button SaveButton;
    }
}
