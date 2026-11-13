using System.ComponentModel;
using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;
using ProjectAutoService.Repositories;

namespace ProjectAutoService.Forms
{
    public partial class FormServiceWork : Form
    {
        private readonly IServiceWorkRepository _serviceWorkRepository;
        private int? _serviceWorkId;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id
        {
            set
            {
                try
                {
                    var serviceWork = _serviceWorkRepository.ReadServiceWorkById(value);
                    if (serviceWork == null)
                    {
                        throw new InvalidDataException(nameof(serviceWork));
                    }
                    foreach (CarBrand elem in Enum.GetValues(typeof(CarBrand)))
                    {
                        if ((elem & serviceWork.CarBrand) != 0)
                        {
                            checkedListBoxCarBrand.SetItemChecked(checkedListBoxCarBrand.Items.IndexOf(elem), true);
                        }
                    }
                    textBoxWorkName.Text = serviceWork.WorkName;
                    numericUpDownNormHours.Value = (decimal)serviceWork.NormHours;
                    numericUpDownPrice.Value = (decimal)serviceWork.Price;
                    _serviceWorkId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public FormServiceWork(IServiceWorkRepository serviceWorkRepository)
        {
            InitializeComponent();
            _serviceWorkRepository = serviceWorkRepository ?? throw new ArgumentNullException(nameof(serviceWorkRepository));
            foreach (var elem in Enum.GetValues(typeof(CarBrand)))
            {
                checkedListBoxCarBrand.Items.Add(elem);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxWorkName.Text) || checkedListBoxCarBrand.CheckedItems.Count == 0)
                {
                    throw new Exception("Имеются незаполненные поля");
                }
                if (_serviceWorkId.HasValue)
                {
                    _serviceWorkRepository.UpdateServiceWork(CreateServiceWork(_serviceWorkId.Value));
                }
                else
                {
                    _serviceWorkRepository.CreateServiceWork(CreateServiceWork(0));
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private ServiceWork CreateServiceWork(int id)
        {
            CarBrand carBrand = CarBrand.None;
            foreach (var elem in checkedListBoxCarBrand.CheckedItems)
            {
                carBrand |= (CarBrand)elem;
            }
            return ServiceWork.CreateEntity(id, carBrand, textBoxWorkName.Text, Convert.ToDouble(numericUpDownNormHours.Value), Convert.ToDouble(numericUpDownPrice.Value));
        }
    }
}