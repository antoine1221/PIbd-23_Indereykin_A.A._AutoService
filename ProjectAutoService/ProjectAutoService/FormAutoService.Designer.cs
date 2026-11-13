namespace ProjectAutoService
{
    partial class FormAutoService
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem directoriesToolStripMenuItem;
        private ToolStripMenuItem mechanicsToolStripMenuItem;
        private ToolStripMenuItem sparePartsToolStripMenuItem;
        private ToolStripMenuItem serviceWorksToolStripMenuItem;
        private ToolStripMenuItem operationsToolStripMenuItem;
        private ToolStripMenuItem serviceOrdersToolStripMenuItem;
        private ToolStripMenuItem partUsagesToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;

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
            menuStripMain = new MenuStrip();
            directoriesToolStripMenuItem = new ToolStripMenuItem();
            mechanicsToolStripMenuItem = new ToolStripMenuItem();
            sparePartsToolStripMenuItem = new ToolStripMenuItem();
            serviceWorksToolStripMenuItem = new ToolStripMenuItem();
            operationsToolStripMenuItem = new ToolStripMenuItem();
            serviceOrdersToolStripMenuItem = new ToolStripMenuItem();
            partUsagesToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            menuStripMain.SuspendLayout();
            SuspendLayout();

            menuStripMain.Items.AddRange(new ToolStripItem[]
            {
                directoriesToolStripMenuItem,
                operationsToolStripMenuItem,
                reportsToolStripMenuItem
            });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(800, 24);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "Главное меню";

            directoriesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                mechanicsToolStripMenuItem,
                sparePartsToolStripMenuItem,
                serviceWorksToolStripMenuItem
            });
            directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            directoriesToolStripMenuItem.Size = new Size(94, 20);
            directoriesToolStripMenuItem.Text = "Справочники";

            mechanicsToolStripMenuItem.Name = "mechanicsToolStripMenuItem";
            mechanicsToolStripMenuItem.Size = new Size(180, 22);
            mechanicsToolStripMenuItem.Text = "Механики";
            mechanicsToolStripMenuItem.Click += MechanicsToolStripMenuItem_Click;

            sparePartsToolStripMenuItem.Name = "sparePartsToolStripMenuItem";
            sparePartsToolStripMenuItem.Size = new Size(180, 22);
            sparePartsToolStripMenuItem.Text = "Запчасти";
            sparePartsToolStripMenuItem.Click += SparePartsToolStripMenuItem_Click;

            serviceWorksToolStripMenuItem.Name = "serviceWorksToolStripMenuItem";
            serviceWorksToolStripMenuItem.Size = new Size(180, 22);
            serviceWorksToolStripMenuItem.Text = "Виды работ";
            serviceWorksToolStripMenuItem.Click += ServiceWorksToolStripMenuItem_Click;

            operationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                serviceOrdersToolStripMenuItem,
                partUsagesToolStripMenuItem
            });
            operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            operationsToolStripMenuItem.Size = new Size(75, 20);
            operationsToolStripMenuItem.Text = "Операции";

            serviceOrdersToolStripMenuItem.Name = "serviceOrdersToolStripMenuItem";
            serviceOrdersToolStripMenuItem.Size = new Size(210, 22);
            serviceOrdersToolStripMenuItem.Text = "Записи на ремонт";
            serviceOrdersToolStripMenuItem.Click += ServiceOrdersToolStripMenuItem_Click;

            partUsagesToolStripMenuItem.Name = "partUsagesToolStripMenuItem";
            partUsagesToolStripMenuItem.Size = new Size(210, 22);
            partUsagesToolStripMenuItem.Text = "Учет расхода запчастей";
            partUsagesToolStripMenuItem.Click += PartUsagesToolStripMenuItem_Click;

            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(60, 20);
            reportsToolStripMenuItem.Text = "Отчеты";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormAutoService";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автосервис";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}