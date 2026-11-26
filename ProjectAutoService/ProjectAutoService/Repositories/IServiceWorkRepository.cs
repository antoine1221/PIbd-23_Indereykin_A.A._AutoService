using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories
{
    public interface IServiceWorkRepository
    {
        IEnumerable<ServiceWork> ReadServiceWorks();
        ServiceWork ReadServiceWorkById(int id);
        void CreateServiceWork(ServiceWork serviceWork);
        void UpdateServiceWork(ServiceWork serviceWork);
        void DeleteServiceWork(int id);
    }
}