using System.ComponentModel.DataAnnotations;

namespace ProjectAutoService.Entities
{
    public class SparePart
    {
        protected SparePart() { }

        [Key]
        public int Id { get; private set; }
        [Required]
        public string VendorCode { get; private set; } = string.Empty;
        [Required]
        public string PartName { get; private set; } = string.Empty;
        public int StockCount { get; private set; }

        public static SparePart CreateEntity(int id, string vendorCode, string partName, int stockCount)
        {
            return new SparePart
            {
                Id = id,
                VendorCode = vendorCode ?? string.Empty,
                PartName = partName ?? string.Empty,
                StockCount = stockCount
            };
        }
    }
}