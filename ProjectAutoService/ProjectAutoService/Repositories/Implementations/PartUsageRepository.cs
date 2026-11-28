using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Repositories.Implementations;

internal sealed class PartUsageRepository(Func<DataContext> createContext, ILogger<PartUsageRepository> logger)
    : RepositoryBase(createContext, logger), IPartUsageRepository
{
    public void CreatePartUsage(PartUsage partUsage) => Run(partUsage, db =>
    {
        var lines = partUsage.SparePartPartUsages;
        if (!lines.Any() || lines.Any(line => line.Count <= 0))
            throw new ArgumentException("Укажите хотя бы одну запчасть и положительное количество для каждой позиции.");
        if (lines.GroupBy(line => line.SparePartId).Any(group => group.Count() > 1))
            throw new ArgumentException("Укажите каждую запчасть одной строкой с общим количеством.");

        using var transaction = db.Database.BeginTransaction();
        try
        {
            db.PartUsages.Add(partUsage);
            db.SaveChanges();
            transaction.Commit();
            return partUsage.Id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }, id => id);

    public void DeletePartUsage(int id) => Run(id, db =>
    {
        using var transaction = db.Database.BeginTransaction();
        try
        {
            var usage = db.PartUsages.Include(x => x.SparePartPartUsages).SingleOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException($"Расход запчастей с кодом {id} не найден.");
            db.PartUsages.Remove(usage);
            db.SaveChanges();
            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }, deletedId => deletedId);

    public IEnumerable<PartUsage> ReadPartUsages(DateTime? dateFrom = null, DateTime? dateTo = null,
        int? sparePartId = null, int? mechanicId = null) =>
        Run(new { dateFrom, dateTo, sparePartId, mechanicId }, db =>
        {
            var usages = db.PartUsages.AsNoTracking();
            if (dateFrom.HasValue) usages = usages.Where(x => x.DateUsage >= dateFrom.Value);
            if (dateTo.HasValue) usages = usages.Where(x => x.DateUsage <= dateTo.Value);
            if (sparePartId.HasValue) usages = usages.Where(x => x.SparePartPartUsages.Any(line => line.SparePartId == sparePartId.Value));
            if (mechanicId.HasValue) usages = usages.Where(x => x.MechanicId == mechanicId.Value);
            return usages.Include(x => x.SparePartPartUsages).OrderBy(x => x.Id).ToList();
        }, rows => rows.Count);
}
