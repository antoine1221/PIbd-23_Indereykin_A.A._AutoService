using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAutoService.Entities
{
    public class SparePartPartUsage
    {
        protected SparePartPartUsage() { }

        [Key]
        public int Id { get; private set; }
        public int PartUsageId { get; private set; }
        [ForeignKey(nameof(PartUsageId))]
        public PartUsage PartUsage { get; private set; } = null!;
        public int SparePartId { get; private set; }
        public int Count { get; private set; }

        public static SparePartPartUsage CreateElement(int id, int sparePartId, int count)
        {
            return new SparePartPartUsage
            {
                Id = id,
                SparePartId = sparePartId,
                Count = count
            };
        }
    }
}