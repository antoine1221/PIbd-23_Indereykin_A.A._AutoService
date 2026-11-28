using System.ComponentModel.DataAnnotations;
using ProjectAutoService.Entities.Enums;

namespace ProjectAutoService.Entities
{
    public class Mechanic
    {
        protected Mechanic() { }

        [Key]
        public int Id { get; private set; }
        [Required]
        public string FullName { get; private set; } = string.Empty;
        public MechanicQualification MechanicQualification { get; private set; }
        public int Experience { get; private set; }

        public static Mechanic CreateEntity(int id, string fullName, MechanicQualification mechanicQualification, int experience)
        {
            return new Mechanic
            {
                Id = id,
                FullName = fullName ?? string.Empty,
                MechanicQualification = mechanicQualification,
                Experience = experience
            };
        }
    }
}