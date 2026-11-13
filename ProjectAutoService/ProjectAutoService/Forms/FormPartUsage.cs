using ProjectAutoService.Entities;
using ProjectAutoService.Repositories;

namespace ProjectAutoService.Forms
{
    public partial class FormPartUsage : Form
    {
        private readonly IPartUsageRepository _partUsageRepository;

        public FormPartUsage(IPartUsageRepository partUsageRepository, IMechanicRepository mechanicRepository, ISparePartRepository sparePartRepository)
        {
            InitializeComponent();
            _partUsageRepository = partUsageRepository ?? throw new ArgumentNullException(nameof(partUsageRepository));

            comboBoxMechanic.DataSource = mechanicRepository.ReadMechanics();
            comboBoxMechanic.DisplayMember = "FullName";
            comboBoxMechanic.ValueMember = "Id";

            ColumnSparePart.DataSource = sparePartRepository.ReadSpareParts();
            ColumnSparePart.DisplayMember = "PartName";
            ColumnSparePart.ValueMember = "Id";
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSpareParts.RowCount < 1 || comboBoxMechanic.SelectedIndex < 0)
                {
                    throw new Exception("Имеются незаполненные поля");
                }
                _partUsageRepository.CreatePartUsage(PartUsage.CreateOperation(0, (int)comboBoxMechanic.SelectedValue!, CreateListSparePartPartUsagesFromDataGrid()));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private List<SparePartPartUsage> CreateListSparePartPartUsagesFromDataGrid()
        {
            var list = new List<SparePartPartUsage>();
            foreach (DataGridViewRow row in dataGridViewSpareParts.Rows)
            {
                if (row.Cells["ColumnSparePart"].Value == null || row.Cells["ColumnCount"].Value == null)
                {
                    continue;
                }
                list.Add(SparePartPartUsage.CreateElement(0, Convert.ToInt32(row.Cells["ColumnSparePart"].Value), Convert.ToInt32(row.Cells["ColumnCount"].Value)));
            }
            return list;
        }
    }
}