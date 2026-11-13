using System.ComponentModel;
using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;
using ProjectAutoService.Repositories;

namespace ProjectAutoService.Forms
{
    public partial class FormMechanic : Form
    {
        private readonly IMechanicRepository _mechanicRepository;
        private int? _mechanicId;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id
        {
            set
            {
                try
                {
                    var mechanic = _mechanicRepository.ReadMechanicById(value);
                    if (mechanic == null)
                    {
                        throw new InvalidDataException(nameof(mechanic));
                    }
                    textBoxFullName.Text = mechanic.FullName;
                    comboBoxQualification.SelectedItem = mechanic.MechanicQualification;
                    numericUpDownExperience.Value = mechanic.Experience;
                    _mechanicId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public FormMechanic(IMechanicRepository mechanicRepository)
        {
            InitializeComponent();
            _mechanicRepository = mechanicRepository ?? throw new ArgumentNullException(nameof(mechanicRepository));
            comboBoxQualification.DataSource = Enum.GetValues(typeof(MechanicQualification));
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFullName.Text) || comboBoxQualification.SelectedIndex < 1)
                {
                    throw new Exception("Имеются незаполненные поля");
                }
                if (_mechanicId.HasValue)
                {
                    _mechanicRepository.UpdateMechanic(CreateMechanic(_mechanicId.Value));
                }
                else
                {
                    _mechanicRepository.CreateMechanic(CreateMechanic(0));
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private Mechanic CreateMechanic(int id) => Mechanic.CreateEntity(id, textBoxFullName.Text, (MechanicQualification)comboBoxQualification.SelectedItem!, Convert.ToInt32(numericUpDownExperience.Value));
    }
}