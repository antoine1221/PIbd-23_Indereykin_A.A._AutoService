using System.ComponentModel.DataAnnotations;
using ProjectAutoService.Entities.Enums;

namespace ProjectAutoService.Entities
{
    public class ServiceWork
    {
        protected ServiceWork() { }

        [Key]
        public int Id { get; private set; }
        public CarBrand CarBrand { get; private set; }
        [Required]
        public string WorkName { get; private set; } = string.Empty;
        public double NormHours { get; private set; }
        public double Price { get; private set; }

        public static ServiceWork CreateEntity(int id, CarBrand carBrand, string workName, double normHours, double price)
        {
            return new ServiceWork
            {
                Id = id,
                CarBrand = carBrand,
                WorkName = workName ?? string.Empty,
                NormHours = normHours,
                Price = price
            };
        }
    }
}