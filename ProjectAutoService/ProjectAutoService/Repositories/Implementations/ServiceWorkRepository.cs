using ProjectAutoService.Entities;
using ProjectAutoService.Entities.Enums;

namespace ProjectAutoService.Repositories.Implementations
{
    internal class ServiceWorkRepository : IServiceWorkRepository
    {
        public void CreateServiceWork(ServiceWork serviceWork)
        {
        }

        public void DeleteServiceWork(int id)
        {
        }

        public ServiceWork ReadServiceWorkById(int id)
        {
            return ServiceWork.CreateEntity(0, CarBrand.None, string.Empty, 0, 0);
        }

        public IEnumerable<ServiceWork> ReadServiceWorks()
        {
            return [];
        }

        public void UpdateServiceWork(ServiceWork serviceWork)
        {
        }
    }
}