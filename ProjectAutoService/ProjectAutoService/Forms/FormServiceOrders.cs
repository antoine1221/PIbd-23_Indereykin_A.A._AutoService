using ProjectAutoService.Entities;
using ProjectAutoService.Repositories;
using Unity;

namespace ProjectAutoService.Forms
{
    public partial class FormServiceOrders : Form
    {
        private readonly IUnityContainer _container;
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public FormServiceOrders(IUnityContainer container, IServiceOrderRepository serviceOrderRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _serviceOrderRepository = serviceOrderRepository ?? throw new ArgumentNullException(nameof(serviceOrderRepository));

            FormDisplay.ConfigureListColumns(dataGridViewData,
                (nameof(ServiceOrder.Id), "Код"),
                (nameof(ServiceOrder.ServiceWorkId), "Код работы"),
                (nameof(ServiceOrder.MechanicId), "Код механика"),
                (nameof(ServiceOrder.SparePartId), "Код запчасти"),
                (nameof(ServiceOrder.OrderDate), "Дата записи"),
                (nameof(ServiceOrder.WorkVolume), "Объём работ"));
        }

        private void FormServiceOrders_Load(object sender, EventArgs e)
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
                _container.Resolve<FormServiceOrder>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadList() => dataGridViewData.DataSource = _serviceOrderRepository.ReadServiceOrders();
    }
}