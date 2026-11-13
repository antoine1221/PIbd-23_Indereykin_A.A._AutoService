namespace ProjectAutoService.Forms
{
    partial class FormSparePart
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelVendorCode;
        private Label labelPartName;
        private Label labelStockCount;
        private TextBox textBoxVendorCode;
        private TextBox textBoxPartName;
        private NumericUpDown numericUpDownStockCount;
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
            labelVendorCode = new Label();
            labelPartName = new Label();
            labelStockCount = new Label();
            textBoxVendorCode = new TextBox();
            textBoxPartName = new TextBox();
            numericUpDownStockCount = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStockCount).BeginInit();
            SuspendLayout();

            labelVendorCode.AutoSize = true;
            labelVendorCode.Location = new Point(25, 25);
            labelVendorCode.Name = "labelVendorCode";
            labelVendorCode.Size = new Size(60, 15);
            labelVendorCode.Text = "Артикул:";

            textBoxVendorCode.Location = new Point(160, 22);
            textBoxVendorCode.Name = "textBoxVendorCode";
            textBoxVendorCode.Size = new Size(200, 23);
            textBoxVendorCode.TabIndex = 0;

            labelPartName.AutoSize = true;
            labelPartName.Location = new Point(25, 65);
            labelPartName.Name = "labelPartName";
            labelPartName.Size = new Size(120, 15);
            labelPartName.Text = "Название запчасти:";

            textBoxPartName.Location = new Point(160, 62);
            textBoxPartName.Name = "textBoxPartName";
            textBoxPartName.Size = new Size(200, 23);
            textBoxPartName.TabIndex = 1;

            labelStockCount.AutoSize = true;
            labelStockCount.Location = new Point(25, 105);
            labelStockCount.Name = "labelStockCount";
            labelStockCount.Size = new Size(130, 15);
            labelStockCount.Text = "Количество на складе:";

            numericUpDownStockCount.Location = new Point(160, 102);
            numericUpDownStockCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownStockCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownStockCount.Name = "numericUpDownStockCount";
            numericUpDownStockCount.Size = new Size(120, 23);
            numericUpDownStockCount.TabIndex = 2;
            numericUpDownStockCount.Value = new decimal(new int[] { 1, 0, 0, 0 });

            buttonSave.Location = new Point(75, 155);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            buttonCancel.Location = new Point(215, 155);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 210);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownStockCount);
            Controls.Add(textBoxPartName);
            Controls.Add(textBoxVendorCode);
            Controls.Add(labelStockCount);
            Controls.Add(labelPartName);
            Controls.Add(labelVendorCode);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormSparePart";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Запчасть";
            ((System.ComponentModel.ISupportInitialize)numericUpDownStockCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}