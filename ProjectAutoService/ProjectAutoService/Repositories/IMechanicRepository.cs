using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories
{
    public interface IMechanicRepository
    {
        IEnumerable<Mechanic> ReadMechanics();
        Mechanic ReadMechanicById(int id);
        void CreateMechanic(Mechanic mechanic);
        void UpdateMechanic(Mechanic mechanic);
        void DeleteMechanic(int id);
    }
}