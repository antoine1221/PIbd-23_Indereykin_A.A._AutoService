using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations
{
    internal class SparePartRepository : ISparePartRepository
    {
        public void CreateSparePart(SparePart sparePart)
        {
        }

        public void DeleteSparePart(int id)
        {
        }

        public SparePart ReadSparePartById(int id)
        {
            return SparePart.CreateEntity(0, string.Empty, string.Empty, 0);
        }

        public IEnumerable<SparePart> ReadSpareParts()
        {
            return [];
        }

        public void UpdateSparePart(SparePart sparePart)
        {
        }
    }
}