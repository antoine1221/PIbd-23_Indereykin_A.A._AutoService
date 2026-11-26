using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories
{
    public interface IPartUsageRepository
    {
        IEnumerable<PartUsage> ReadPartUsages(DateTime? dateFrom = null, DateTime? dateTo = null, int? sparePartId = null, int? mechanicId = null);
        void CreatePartUsage(PartUsage partUsage);
        void DeletePartUsage(int id);
    }
}