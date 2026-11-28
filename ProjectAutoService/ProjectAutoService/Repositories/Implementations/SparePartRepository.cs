using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations;

internal sealed class SparePartRepository(Func<DataContext> createContext, ILogger<SparePartRepository> logger)
    : RepositoryBase(createContext, logger), ISparePartRepository
{
    public IEnumerable<SparePart> ReadSpareParts() => Run(null,
        db => db.SpareParts.AsNoTracking().OrderBy(x => x.Id).ToList(), rows => rows.Count);

    public SparePart ReadSparePartById(int id) => Run(id,
        db => db.SpareParts.AsNoTracking().SingleOrDefault(x => x.Id == id) ?? Missing(id), x => x.Id);

    public void CreateSparePart(SparePart entity) => Run(entity, db =>
    {
        db.SpareParts.Add(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void UpdateSparePart(SparePart entity) => Run(entity, db =>
    {
        var existing = db.SpareParts.Find(entity.Id) ?? Missing(entity.Id);
        db.Entry(existing).CurrentValues.SetValues(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void DeleteSparePart(int id) => Run(id, db =>
    {
        var existing = db.SpareParts.Find(id) ?? Missing(id);
        db.SpareParts.Remove(existing);
        db.SaveChanges();
        return id;
    }, deletedId => deletedId);

    private static SparePart Missing(int id) =>
        throw new KeyNotFoundException($"Запчасть с кодом {id} не найдена.");
}
