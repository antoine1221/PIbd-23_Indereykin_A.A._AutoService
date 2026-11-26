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
                if (comboBoxMechanic.SelectedValue is not int mechanicId)
                {
                    throw new InvalidOperationException("Выберите механика.");
                }
                if (!dataGridViewSpareParts.EndEdit())
                {
                    throw new InvalidOperationException("Не удалось завершить ввод в таблице запчастей.");
                }

                var spareParts = CreateListSparePartPartUsagesFromDataGrid();
                _partUsageRepository.CreatePartUsage(PartUsage.CreateOperation(0, mechanicId, spareParts));
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
                if (row.IsNewRow)
                {
                    continue;
                }

                var rowNumber = row.Index + 1;
                if (row.Cells[ColumnSparePart.Index].Value is not int sparePartId)
                {
                    throw new InvalidOperationException($"Строка {rowNumber}: выберите запчасть.");
                }
                if (!int.TryParse(row.Cells[ColumnCount.Index].Value?.ToString(), out var count) || count <= 0)
                {
                    throw new InvalidOperationException($"Строка {rowNumber}: количество должно быть целым числом больше нуля.");
                }
                list.Add(SparePartPartUsage.CreateElement(0, sparePartId, count));
            }

            if (list.Count == 0)
            {
                throw new InvalidOperationException("Добавьте хотя бы одну запчасть.");
            }
            return list;
        }
    }
}