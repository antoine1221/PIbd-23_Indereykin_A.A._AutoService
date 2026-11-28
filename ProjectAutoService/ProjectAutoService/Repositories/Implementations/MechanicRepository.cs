using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations;

internal sealed class MechanicRepository(Func<DataContext> createContext, ILogger<MechanicRepository> logger)
    : RepositoryBase(createContext, logger), IMechanicRepository
{
    public IEnumerable<Mechanic> ReadMechanics() => Run(null,
        db => db.Mechanics.AsNoTracking().OrderBy(x => x.Id).ToList(), rows => rows.Count);

    public Mechanic ReadMechanicById(int id) => Run(id,
        db => db.Mechanics.AsNoTracking().SingleOrDefault(x => x.Id == id) ?? Missing(id), x => x.Id);

    public void CreateMechanic(Mechanic entity) => Run(entity, db =>
    {
        db.Mechanics.Add(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void UpdateMechanic(Mechanic entity) => Run(entity, db =>
    {
        var existing = db.Mechanics.Find(entity.Id) ?? Missing(entity.Id);
        db.Entry(existing).CurrentValues.SetValues(entity);
        db.SaveChanges();
        return entity.Id;
    }, id => id);

    public void DeleteMechanic(int id) => Run(id, db =>
    {
        var existing = db.Mechanics.Find(id) ?? Missing(id);
        db.Mechanics.Remove(existing);
        db.SaveChanges();
        return id;
    }, deletedId => deletedId);

    private static Mechanic Missing(int id) =>
        throw new KeyNotFoundException($"Карточка механика с кодом {id} не найдена.");
}
