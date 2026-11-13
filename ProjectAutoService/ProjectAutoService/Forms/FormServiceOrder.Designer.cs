namespace ProjectAutoService.Forms
{
    partial class FormServiceOrder
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelServiceWork;
        private Label labelMechanic;
        private Label labelSparePart;
        private Label labelWorkVolume;
        private ComboBox comboBoxServiceWork;
        private ComboBox comboBoxMechanic;
        private ComboBox comboBoxSparePart;
        private NumericUpDown numericUpDownWorkVolume;
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
            labelServiceWork = new Label();
            labelMechanic = new Label();
            labelSparePart = new Label();
            labelWorkVolume = new Label();
            comboBoxServiceWork = new ComboBox();
            comboBoxMechanic = new ComboBox();
            comboBoxSparePart = new ComboBox();
            numericUpDownWorkVolume = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorkVolume).BeginInit();
            SuspendLayout();

            labelServiceWork.AutoSize = true;
            labelServiceWork.Location = new Point(25, 25);
            labelServiceWork.Name = "labelServiceWork";
            labelServiceWork.Size = new Size(75, 15);
            labelServiceWork.Text = "Вид работы:";

            comboBoxServiceWork.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceWork.FormattingEnabled = true;
            comboBoxServiceWork.Location = new Point(140, 22);
            comboBoxServiceWork.Name = "comboBoxServiceWork";
            comboBoxServiceWork.Size = new Size(210, 23);
            comboBoxServiceWork.TabIndex = 0;

            labelMechanic.AutoSize = true;
            labelMechanic.Location = new Point(25, 65);
            labelMechanic.Name = "labelMechanic";
            labelMechanic.Size = new Size(60, 15);
            labelMechanic.Text = "Механик:";

            comboBoxMechanic.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMechanic.FormattingEnabled = true;
            comboBoxMechanic.Location = new Point(140, 62);
            comboBoxMechanic.Name = "comboBoxMechanic";
            comboBoxMechanic.Size = new Size(210, 23);
            comboBoxMechanic.TabIndex = 1;

            labelSparePart.AutoSize = true;
            labelSparePart.Location = new Point(25, 105);
            labelSparePart.Name = "labelSparePart";
            labelSparePart.Size = new Size(60, 15);
            labelSparePart.Text = "Запчасть:";

            comboBoxSparePart.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSparePart.FormattingEnabled = true;
            comboBoxSparePart.Location = new Point(140, 102);
            comboBoxSparePart.Name = "comboBoxSparePart";
            comboBoxSparePart.Size = new Size(210, 23);
            comboBoxSparePart.TabIndex = 2;

            labelWorkVolume.AutoSize = true;
            labelWorkVolume.Location = new Point(25, 145);
            labelWorkVolume.Name = "labelWorkVolume";
            labelWorkVolume.Size = new Size(85, 15);
            labelWorkVolume.Text = "Объем работ:";

            numericUpDownWorkVolume.Location = new Point(140, 142);
            numericUpDownWorkVolume.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownWorkVolume.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownWorkVolume.Name = "numericUpDownWorkVolume";
            numericUpDownWorkVolume.Size = new Size(120, 23);
            numericUpDownWorkVolume.TabIndex = 3;
            numericUpDownWorkVolume.Value = new decimal(new int[] { 1, 0, 0, 0 });

            buttonSave.Location = new Point(70, 195);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            buttonCancel.Location = new Point(210, 195);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 245);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownWorkVolume);
            Controls.Add(comboBoxSparePart);
            Controls.Add(comboBoxMechanic);
            Controls.Add(comboBoxServiceWork);
            Controls.Add(labelWorkVolume);
            Controls.Add(labelSparePart);
            Controls.Add(labelMechanic);
            Controls.Add(labelServiceWork);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormServiceOrder";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Запись на ремонт";
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorkVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}