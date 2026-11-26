using ProjectAutoService.Entities;
using ProjectAutoService.Repositories;
using Unity;

namespace ProjectAutoService.Forms
{
    public partial class FormPartUsages : Form
    {
        private readonly IUnityContainer _container;
        private readonly IPartUsageRepository _partUsageRepository;

        public FormPartUsages(IUnityContainer container, IPartUsageRepository partUsageRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _partUsageRepository = partUsageRepository ?? throw new ArgumentNullException(nameof(partUsageRepository));

            FormDisplay.ConfigureListColumns(dataGridViewData,
                (nameof(PartUsage.Id), "Код"),
                (nameof(PartUsage.MechanicId), "Код механика"),
                (nameof(PartUsage.DateUsage), "Дата расхода"),
                (nameof(PartUsage.SparePartPartUsages), "Запчасти"));
            dataGridViewData.CellFormatting += (_, e) =>
            {
                if (e.ColumnIndex >= 0
                    && dataGridViewData.Columns[e.ColumnIndex].Name == nameof(PartUsage.SparePartPartUsages)
                    && e.Value is IEnumerable<SparePartPartUsage> spareParts)
                {
                    e.Value = string.Join("; ", spareParts.Select(part => $"№ {part.SparePartId}: {part.Count} шт."));
                    e.FormattingApplied = true;
                }
            };
        }

        private void FormPartUsages_Load(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormPartUsage>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId))
            {
                return;
            }
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                _partUsageRepository.DeletePartUsage(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadList() => dataGridViewData.DataSource = _partUsageRepository.ReadPartUsages();

        private bool TryGetIdentifierFromSelectedRow(out int id)
        {
            id = 0;
            if (dataGridViewData.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}