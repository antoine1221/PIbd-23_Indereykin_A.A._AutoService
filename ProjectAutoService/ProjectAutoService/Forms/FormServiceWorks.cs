using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;
using ProjectAutoService.Repositories;
using Unity;

namespace ProjectAutoService.Forms
{
    public partial class FormServiceWorks : Form
    {
        private readonly IUnityContainer _container;
        private readonly IServiceWorkRepository _serviceWorkRepository;

        public FormServiceWorks(IUnityContainer container, IServiceWorkRepository serviceWorkRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _serviceWorkRepository = serviceWorkRepository ?? throw new ArgumentNullException(nameof(serviceWorkRepository));

            FormDisplay.ConfigureListColumns(dataGridViewData,
                (nameof(ServiceWork.Id), "Код"),
                (nameof(ServiceWork.CarBrand), "Марки авто"),
                (nameof(ServiceWork.WorkName), "Наименование"),
                (nameof(ServiceWork.NormHours), "Нормо-часы"),
                (nameof(ServiceWork.Price), "Стоимость"));
            dataGridViewData.CellFormatting += (_, e) =>
            {
                if (e.ColumnIndex >= 0
                    && dataGridViewData.Columns[e.ColumnIndex].Name == nameof(ServiceWork.CarBrand)
                    && e.Value is CarBrand.None)
                {
                    e.Value = "Не указаны";
                    e.FormattingApplied = true;
                }
            };
        }

        private void FormServiceWorks_Load(object sender, EventArgs e)
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
                _container.Resolve<FormServiceWork>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId))
            {
                return;
            }
            try
            {
                var form = _container.Resolve<FormServiceWork>();
                form.Id = findId;
                form.ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при изменении", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _serviceWorkRepository.DeleteServiceWork(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(FormDisplay.DirectoryDeleteError(ex), "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadList() => dataGridViewData.DataSource = _serviceWorkRepository.ReadServiceWorks();

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