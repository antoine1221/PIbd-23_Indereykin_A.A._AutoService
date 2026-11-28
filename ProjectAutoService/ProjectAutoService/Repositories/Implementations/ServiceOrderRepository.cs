using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations;

internal sealed class ServiceOrderRepository(Func<DataContext> createContext, ILogger<ServiceOrderRepository> logger)
    : RepositoryBase(createContext, logger), IServiceOrderRepository
{
    public void CreateServiceOrder(ServiceOrder serviceOrder) => Run(serviceOrder, db =>
    {
        db.ServiceOrders.Add(serviceOrder);
        db.SaveChanges();
        return serviceOrder.Id;
    }, id => id);

    public IEnumerable<ServiceOrder> ReadServiceOrders(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? serviceWorkId = null, int? mechanicId = null, int? sparePartId = null) =>
        Run(new { dateFrom, dateTo, serviceWorkId, mechanicId, sparePartId }, db =>
        {
            var orders = db.ServiceOrders.AsNoTracking();
            if (dateFrom.HasValue) orders = orders.Where(x => x.OrderDate >= dateFrom.Value);
            if (dateTo.HasValue) orders = orders.Where(x => x.OrderDate <= dateTo.Value);
            if (serviceWorkId.HasValue) orders = orders.Where(x => x.ServiceWorkId == serviceWorkId.Value);
            if (mechanicId.HasValue) orders = orders.Where(x => x.MechanicId == mechanicId.Value);
            if (sparePartId.HasValue) orders = orders.Where(x => x.SparePartId == sparePartId.Value);
            return orders.OrderBy(x => x.Id).ToList();
        }, rows => rows.Count);
}
