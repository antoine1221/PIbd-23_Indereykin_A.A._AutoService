using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations
{
    internal class ServiceOrderRepository : IServiceOrderRepository
    {
        public void CreateServiceOrder(ServiceOrder serviceOrder)
        {
        }

        public IEnumerable<ServiceOrder> ReadServiceOrders(DateTime? dateFrom = null, DateTime? dateTo = null, int? serviceWorkId = null, int? mechanicId = null, int? sparePartId = null)
        {
            return [];
        }
    }
}