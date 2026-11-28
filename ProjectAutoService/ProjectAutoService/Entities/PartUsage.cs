using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAutoService.Entities
{
    public class PartUsage
    {
        protected PartUsage() { }

        [Key]
        public int Id { get; private set; }
        public int MechanicId { get; private set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DateUsage { get; private set; }
        public List<SparePartPartUsage> SparePartPartUsages { get; private set; } = [];

        public static PartUsage CreateOperation(int id, int mechanicId, IEnumerable<SparePartPartUsage> sparePartPartUsages)
        {
            return new PartUsage
            {
                Id = id,
                MechanicId = mechanicId,
                DateUsage = DateTime.Now,
                SparePartPartUsages = sparePartPartUsages?.ToList() ?? []
            };
        }
    }
}