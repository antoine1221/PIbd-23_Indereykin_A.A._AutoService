using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories
{
    public interface IServiceOrderRepository
    {
        IEnumerable<ServiceOrder> ReadServiceOrders(DateTime? dateFrom = null, DateTime? dateTo = null, int? serviceWorkId = null, int? mechanicId = null, int? sparePartId = null);
        void CreateServiceOrder(ServiceOrder serviceOrder);
    }
}