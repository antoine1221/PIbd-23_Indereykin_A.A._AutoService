namespace ProjectAutoService.Forms
{
    partial class FormServiceWork
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelCarBrand;
        private Label labelWorkName;
        private Label labelNormHours;
        private Label labelPrice;
        private CheckedListBox checkedListBoxCarBrand;
        private TextBox textBoxWorkName;
        private NumericUpDown numericUpDownNormHours;
        private NumericUpDown numericUpDownPrice;
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
            labelCarBrand = new Label();
            labelWorkName = new Label();
            labelNormHours = new Label();
            labelPrice = new Label();
            checkedListBoxCarBrand = new CheckedListBox();
            textBoxWorkName = new TextBox();
            numericUpDownNormHours = new NumericUpDown();
            numericUpDownPrice = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();

            labelCarBrand.AutoSize = true;
            labelCarBrand.Location = new Point(25, 25);
            labelCarBrand.Name = "labelCarBrand";
            labelCarBrand.Size = new Size(80, 15);
            labelCarBrand.Text = "Марки авто:";

            checkedListBoxCarBrand.FormattingEnabled = true;
            checkedListBoxCarBrand.Location = new Point(140, 22);
            checkedListBoxCarBrand.Name = "checkedListBoxCarBrand";
            checkedListBoxCarBrand.Size = new Size(210, 94);
            checkedListBoxCarBrand.TabIndex = 0;

            labelWorkName.AutoSize = true;
            labelWorkName.Location = new Point(25, 135);
            labelWorkName.Name = "labelWorkName";
            labelWorkName.Size = new Size(95, 15);
            labelWorkName.Text = "Наименование:";

            textBoxWorkName.Location = new Point(140, 132);
            textBoxWorkName.Name = "textBoxWorkName";
            textBoxWorkName.Size = new Size(210, 23);
            textBoxWorkName.TabIndex = 1;

            labelNormHours.AutoSize = true;
            labelNormHours.Location = new Point(25, 175);
            labelNormHours.Name = "labelNormHours";
            labelNormHours.Size = new Size(80, 15);
            labelNormHours.Text = "Нормо-часы:";

            numericUpDownNormHours.DecimalPlaces = 2;
            numericUpDownNormHours.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDownNormHours.Location = new Point(140, 172);
            numericUpDownNormHours.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownNormHours.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownNormHours.Name = "numericUpDownNormHours";
            numericUpDownNormHours.Size = new Size(120, 23);
            numericUpDownNormHours.TabIndex = 2;
            numericUpDownNormHours.Value = new decimal(new int[] { 1, 0, 0, 0 });

            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(25, 215);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(70, 15);
            labelPrice.Text = "Стоимость:";

            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(140, 212);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(120, 23);
            numericUpDownPrice.TabIndex = 3;
            numericUpDownPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });

            buttonSave.Location = new Point(70, 260);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            buttonCancel.Location = new Point(210, 260);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 315);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownPrice);
            Controls.Add(numericUpDownNormHours);
            Controls.Add(textBoxWorkName);
            Controls.Add(checkedListBoxCarBrand);
            Controls.Add(labelPrice);
            Controls.Add(labelNormHours);
            Controls.Add(labelWorkName);
            Controls.Add(labelCarBrand);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormServiceWork";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Вид работы";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}