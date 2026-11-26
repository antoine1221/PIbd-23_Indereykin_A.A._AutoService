using ProjectAutoService.Entities;
using ProjectAutoService.Repositories;

namespace ProjectAutoService.Forms
{
    public partial class FormServiceOrder : Form
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public FormServiceOrder(IServiceOrderRepository serviceOrderRepository, IServiceWorkRepository serviceWorkRepository, IMechanicRepository mechanicRepository, ISparePartRepository sparePartRepository)
        {
            InitializeComponent();
            _serviceOrderRepository = serviceOrderRepository ?? throw new ArgumentNullException(nameof(serviceOrderRepository));

            comboBoxMechanic.DataSource = mechanicRepository.ReadMechanics();
            comboBoxMechanic.DisplayMember = "FullName";
            comboBoxMechanic.ValueMember = "Id";

            comboBoxServiceWork.DataSource = serviceWorkRepository.ReadServiceWorks();
            comboBoxServiceWork.DisplayMember = "WorkName";
            comboBoxServiceWork.ValueMember = "Id";

            comboBoxSparePart.DataSource = sparePartRepository.ReadSpareParts();
            comboBoxSparePart.DisplayMember = "PartName";
            comboBoxSparePart.ValueMember = "Id";
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxServiceWork.SelectedIndex < 0 || comboBoxMechanic.SelectedIndex < 0 || comboBoxSparePart.SelectedIndex < 0)
                {
                    throw new Exception("Имеются незаполненные поля");
                }
                _serviceOrderRepository.CreateServiceOrder(ServiceOrder.CreateOperation(0, (int)comboBoxServiceWork.SelectedValue!, (int)comboBoxMechanic.SelectedValue!, (int)comboBoxSparePart.SelectedValue!, Convert.ToInt32(numericUpDownWorkVolume.Value)));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();
    }
}