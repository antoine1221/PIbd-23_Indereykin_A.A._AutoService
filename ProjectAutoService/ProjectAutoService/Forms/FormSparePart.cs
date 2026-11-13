using System.ComponentModel;
using ProjectAutoService.Entities;
using ProjectAutoService.Repositories;

namespace ProjectAutoService.Forms
{
    public partial class FormSparePart : Form
    {
        private readonly ISparePartRepository _sparePartRepository;
        private int? _sparePartId;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id
        {
            set
            {
                try
                {
                    var sparePart = _sparePartRepository.ReadSparePartById(value);
                    if (sparePart == null)
                    {
                        throw new InvalidDataException(nameof(sparePart));
                    }
                    textBoxVendorCode.Text = sparePart.VendorCode;
                    textBoxPartName.Text = sparePart.PartName;
                    numericUpDownStockCount.Value = sparePart.StockCount;
                    _sparePartId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public FormSparePart(ISparePartRepository sparePartRepository)
        {
            InitializeComponent();
            _sparePartRepository = sparePartRepository ?? throw new ArgumentNullException(nameof(sparePartRepository));
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxVendorCode.Text) || string.IsNullOrWhiteSpace(textBoxPartName.Text))
                {
                    throw new Exception("Имеются незаполненные поля");
                }
                if (_sparePartId.HasValue)
                {
                    _sparePartRepository.UpdateSparePart(CreateSparePart(_sparePartId.Value));
                }
                else
                {
                    _sparePartRepository.CreateSparePart(CreateSparePart(0));
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private SparePart CreateSparePart(int id) => SparePart.CreateEntity(id, textBoxVendorCode.Text, textBoxPartName.Text, Convert.ToInt32(numericUpDownStockCount.Value));
    }
}