namespace DDDNET8.UI.Views
{
    partial class WeatherSaveView
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
            SaveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            AreaIdComboBox = new ComboBox();
            ConditionComboBox = new ComboBox();
            DateTimeTextBox = new DateTimePicker();
            TemperatureTextBox = new TextBox();
            UnitLabel = new Label();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(29, 27);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(112, 34);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 97);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 1;
            label1.Text = "地域";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 152);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 2;
            label2.Text = "日時";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 211);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 3;
            label3.Text = "状態";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 268);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 4;
            label4.Text = "温度";
            // 
            // AreaIdComboBox
            // 
            AreaIdComboBox.FormattingEnabled = true;
            AreaIdComboBox.Location = new Point(148, 94);
            AreaIdComboBox.Name = "AreaIdComboBox";
            AreaIdComboBox.Size = new Size(182, 33);
            AreaIdComboBox.TabIndex = 5;
            // 
            // ConditionComboBox
            // 
            ConditionComboBox.FormattingEnabled = true;
            ConditionComboBox.Location = new Point(148, 208);
            ConditionComboBox.Name = "ConditionComboBox";
            ConditionComboBox.Size = new Size(182, 33);
            ConditionComboBox.TabIndex = 6;
            // 
            // DateTimeTextBox
            // 
            DateTimeTextBox.CustomFormat = "yyyy/MM/dd HH:mm";
            DateTimeTextBox.Format = DateTimePickerFormat.Custom;
            DateTimeTextBox.Location = new Point(148, 147);
            DateTimeTextBox.Name = "DateTimeTextBox";
            DateTimeTextBox.Size = new Size(238, 31);
            DateTimeTextBox.TabIndex = 7;
            // 
            // TemperatureTextBox
            // 
            TemperatureTextBox.Location = new Point(148, 265);
            TemperatureTextBox.Name = "TemperatureTextBox";
            TemperatureTextBox.Size = new Size(150, 31);
            TemperatureTextBox.TabIndex = 8;
            // 
            // UnitLabel
            // 
            UnitLabel.AutoSize = true;
            UnitLabel.Location = new Point(314, 268);
            UnitLabel.Name = "UnitLabel";
            UnitLabel.Size = new Size(34, 25);
            UnitLabel.TabIndex = 9;
            UnitLabel.Text = "XX";
            // 
            // WeatherSaveView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 372);
            Controls.Add(UnitLabel);
            Controls.Add(TemperatureTextBox);
            Controls.Add(DateTimeTextBox);
            Controls.Add(ConditionComboBox);
            Controls.Add(AreaIdComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Name = "WeatherSaveView";
            Text = "WeatherSaveView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox AreaIdComboBox;
        private ComboBox ConditionComboBox;
        private DateTimePicker DateTimeTextBox;
        private TextBox TemperatureTextBox;
        private Label UnitLabel;
    }
}