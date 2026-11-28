using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations;

internal sealed class ServiceWorkRepository(Func<DataContext> createContext, ILogger<ServiceWorkRepository> logger)
    : RepositoryBase(createContext, logger), IServiceWorkRepository
{
    public IEnumerable<ServiceWork> ReadServiceWorks() => Run(null,
        db => db.ServiceWorks.AsNoTracking().OrderBy(x => x.Id).ToList(), rows => rows.Count);

    public ServiceWork ReadServiceWorkById(int id) => Run(id,
        db => db.ServiceWorks.AsNoTracking().SingleOrDefault(x => x.Id == id) ?? Missing(id), x => x.Id);

    public void CreateServiceWork(ServiceWork entity) => Run(entity, db =>
    {
        db.ServiceWorks.Add(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void UpdateServiceWork(ServiceWork entity) => Run(entity, db =>
    {
        var existing = db.ServiceWorks.Find(entity.Id) ?? Missing(entity.Id);
        db.Entry(existing).CurrentValues.SetValues(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void DeleteServiceWork(int id) => Run(id, db =>
    {
        var existing = db.ServiceWorks.Find(id) ?? Missing(id);
        db.ServiceWorks.Remove(existing);
        db.SaveChanges();
        return id;
    }, deletedId => deletedId);

    private static ServiceWork Missing(int id) =>
        throw new KeyNotFoundException($"Работа с кодом {id} не найдена.");
}
