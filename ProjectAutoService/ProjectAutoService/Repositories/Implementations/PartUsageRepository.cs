using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations
{
    internal class PartUsageRepository : IPartUsageRepository
    {
        public void CreatePartUsage(PartUsage partUsage)
        {
        }

        public void DeletePartUsage(int id)
        {
        }

        public IEnumerable<PartUsage> ReadPartUsages(DateTime? dateFrom = null, DateTime? dateTo = null, int? sparePartId = null, int? mechanicId = null)
        {
            return [];
        }
    }
}