using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;

namespace ProjectAutoService.Repositories.Implementations
{
    internal class MechanicRepository : IMechanicRepository
    {
        public void CreateMechanic(Mechanic mechanic)
        {
        }

        public void DeleteMechanic(int id)
        {
        }

        public Mechanic ReadMechanicById(int id)
        {
            return Mechanic.CreateEntity(0, string.Empty, MechanicQualification.None, 0);
        }

        public IEnumerable<Mechanic> ReadMechanics()
        {
            return [];
        }

        public void UpdateMechanic(Mechanic mechanic)
        {
        }
    }
}