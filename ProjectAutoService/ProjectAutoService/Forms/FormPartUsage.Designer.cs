namespace ProjectAutoService.Forms
{
    partial class FormPartUsage
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelMechanic;
        private ComboBox comboBoxMechanic;
        private GroupBox groupBoxSpareParts;
        private DataGridView dataGridViewSpareParts;
        private DataGridViewComboBoxColumn ColumnSparePart;
        private DataGridViewTextBoxColumn ColumnCount;
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
            labelMechanic = new Label();
            comboBoxMechanic = new ComboBox();
            groupBoxSpareParts = new GroupBox();
            dataGridViewSpareParts = new DataGridView();
            ColumnSparePart = new DataGridViewComboBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            buttonCancel = new Button();
            groupBoxSpareParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpareParts).BeginInit();
            SuspendLayout();

            labelMechanic.AutoSize = true;
            labelMechanic.Location = new Point(25, 25);
            labelMechanic.Name = "labelMechanic";
            labelMechanic.Size = new Size(60, 15);
            labelMechanic.Text = "Механик:";

            comboBoxMechanic.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMechanic.FormattingEnabled = true;
            comboBoxMechanic.Location = new Point(105, 22);
            comboBoxMechanic.Name = "comboBoxMechanic";
            comboBoxMechanic.Size = new Size(250, 23);
            comboBoxMechanic.TabIndex = 0;

            groupBoxSpareParts.Controls.Add(dataGridViewSpareParts);
            groupBoxSpareParts.Location = new Point(25, 60);
            groupBoxSpareParts.Name = "groupBoxSpareParts";
            groupBoxSpareParts.Size = new Size(330, 220);
            groupBoxSpareParts.TabIndex = 1;
            groupBoxSpareParts.TabStop = false;
            groupBoxSpareParts.Text = "Запчасти";

            dataGridViewSpareParts.AllowUserToResizeColumns = false;
            dataGridViewSpareParts.AllowUserToResizeRows = false;
            dataGridViewSpareParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSpareParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpareParts.Columns.AddRange(new DataGridViewColumn[] { ColumnSparePart, ColumnCount });
            dataGridViewSpareParts.Dock = DockStyle.Fill;
            dataGridViewSpareParts.Location = new Point(3, 19);
            dataGridViewSpareParts.MultiSelect = false;
            dataGridViewSpareParts.Name = "dataGridViewSpareParts";
            dataGridViewSpareParts.RowHeadersVisible = false;
            dataGridViewSpareParts.Size = new Size(324, 198);
            dataGridViewSpareParts.TabIndex = 0;

            ColumnSparePart.HeaderText = "Запчасть";
            ColumnSparePart.Name = "ColumnSparePart";

            ColumnCount.HeaderText = "Количество";
            ColumnCount.Name = "ColumnCount";

            buttonSave.Location = new Point(65, 295);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            buttonCancel.Location = new Point(215, 295);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 345);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(groupBoxSpareParts);
            Controls.Add(comboBoxMechanic);
            Controls.Add(labelMechanic);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormPartUsage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Расход запчастей";
            groupBoxSpareParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpareParts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}