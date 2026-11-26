using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;
using ProjectAutoService.Repositories;
using Unity;

namespace ProjectAutoService.Forms
{
    public partial class FormMechanics : Form
    {
        private readonly IUnityContainer _container;
        private readonly IMechanicRepository _mechanicRepository;

        public FormMechanics(IUnityContainer container, IMechanicRepository mechanicRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _mechanicRepository = mechanicRepository ?? throw new ArgumentNullException(nameof(mechanicRepository));

            FormDisplay.ConfigureListColumns(dataGridViewData,
                (nameof(Mechanic.Id), "Код"),
                (nameof(Mechanic.FullName), "ФИО"),
                (nameof(Mechanic.MechanicQualification), "Квалификация"),
                (nameof(Mechanic.Experience), "Стаж"));
            dataGridViewData.CellFormatting += (_, e) =>
            {
                if (e.ColumnIndex >= 0
                    && dataGridViewData.Columns[e.ColumnIndex].Name == nameof(Mechanic.MechanicQualification)
                    && e.Value is MechanicQualification qualification)
                {
                    e.Value = FormDisplay.QualificationName(qualification);
                    e.FormattingApplied = true;
                }
            };
        }

        private void FormMechanics_Load(object sender, EventArgs e)
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
                _container.Resolve<FormMechanic>().ShowDialog();
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
                var form = _container.Resolve<FormMechanic>();
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
                _mechanicRepository.DeleteMechanic(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadList() => dataGridViewData.DataSource = _mechanicRepository.ReadMechanics();

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