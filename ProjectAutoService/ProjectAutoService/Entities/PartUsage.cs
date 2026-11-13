namespace ProjectAutoService.Entities
{
    public class PartUsage
    {
        public int Id { get; private set; }
        public int MechanicId { get; private set; }
        public DateTime DateUsage { get; private set; }
        public IEnumerable<SparePartPartUsage> SparePartPartUsages { get; private set; } = [];

        public static PartUsage CreateOperation(int id, int mechanicId, IEnumerable<SparePartPartUsage> sparePartPartUsages)
        {
            return new PartUsage
            {
                Id = id,
                MechanicId = mechanicId,
                DateUsage = DateTime.Now,
                SparePartPartUsages = sparePartPartUsages ?? []
            };
        }
    }
}