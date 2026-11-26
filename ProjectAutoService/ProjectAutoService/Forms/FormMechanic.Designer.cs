namespace ProjectAutoService.Forms
{
    partial class FormMechanic
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelFullName;
        private Label labelQualification;
        private Label labelExperience;
        private TextBox textBoxFullName;
        private ComboBox comboBoxQualification;
        private NumericUpDown numericUpDownExperience;
        private Button buttonSave;
        private Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelFullName = new Label();
            labelQualification = new Label();
            labelExperience = new Label();
            textBoxFullName = new TextBox();
            comboBoxQualification = new ComboBox();
            numericUpDownExperience = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).BeginInit();
            SuspendLayout();

            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(25, 25);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(40, 15);
            labelFullName.Text = "ФИО:";

            textBoxFullName.Location = new Point(140, 22);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(210, 23);
            textBoxFullName.TabIndex = 0;

            labelQualification.AutoSize = true;
            labelQualification.Location = new Point(25, 65);
            labelQualification.Name = "labelQualification";
            labelQualification.Size = new Size(95, 15);
            labelQualification.Text = "Квалификация:";

            comboBoxQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQualification.FormattingEnabled = true;
            comboBoxQualification.Location = new Point(140, 62);
            comboBoxQualification.Name = "comboBoxQualification";
            comboBoxQualification.Size = new Size(210, 23);
            comboBoxQualification.TabIndex = 1;

            labelExperience.AutoSize = true;
            labelExperience.Location = new Point(25, 105);
            labelExperience.Name = "labelExperience";
            labelExperience.Size = new Size(40, 15);
            labelExperience.Text = "Стаж:";

            numericUpDownExperience.Location = new Point(140, 102);
            numericUpDownExperience.Maximum = new decimal(new int[] { 70, 0, 0, 0 });
            numericUpDownExperience.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numericUpDownExperience.Name = "numericUpDownExperience";
            numericUpDownExperience.Size = new Size(120, 23);
            numericUpDownExperience.TabIndex = 2;

            buttonSave.Location = new Point(70, 155);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            buttonCancel.Location = new Point(210, 155);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 210);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownExperience);
            Controls.Add(comboBoxQualification);
            Controls.Add(textBoxFullName);
            Controls.Add(labelExperience);
            Controls.Add(labelQualification);
            Controls.Add(labelFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormMechanic";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Механик";
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}