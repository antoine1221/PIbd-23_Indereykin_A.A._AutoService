using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectAutoService.Entities;

namespace ProjectAutoService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Mechanic> Mechanics => Set<Mechanic>();
        public DbSet<ServiceWork> ServiceWorks => Set<ServiceWork>();
        public DbSet<SparePart> SpareParts => Set<SparePart>();
        public DbSet<ServiceOrder> ServiceOrders => Set<ServiceOrder>();
        public DbSet<PartUsage> PartUsages => Set<PartUsage>();
        public DbSet<SparePartPartUsage> SparePartPartUsages => Set<SparePartPartUsage>();

        internal static string? DesktopPassword { private get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = Environment.GetEnvironmentVariable("AUTOSERVICE_CONNECTION_STRING");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                using var configuration = new ConfigurationManager();
                configuration.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                connectionString = configuration.GetConnectionString("AutoService");
            }
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Укажите ConnectionStrings:AutoService в appsettings.json или переменную AUTOSERVICE_CONNECTION_STRING.");
            }
            if (DesktopPassword is not null)
                connectionString = new Npgsql.NpgsqlConnectionStringBuilder(connectionString) { Password = DesktopPassword }.ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var order = modelBuilder.Entity<ServiceOrder>();
            order.HasOne<Mechanic>().WithMany().HasForeignKey(x => x.MechanicId).OnDelete(DeleteBehavior.Restrict);
            order.HasOne<ServiceWork>().WithMany().HasForeignKey(x => x.ServiceWorkId).OnDelete(DeleteBehavior.Restrict);
            order.HasOne<SparePart>().WithMany().HasForeignKey(x => x.SparePartId).OnDelete(DeleteBehavior.Restrict);

            var usage = modelBuilder.Entity<PartUsage>();
            usage.HasOne<Mechanic>().WithMany().HasForeignKey(x => x.MechanicId).OnDelete(DeleteBehavior.Restrict);
            usage.HasMany(x => x.SparePartPartUsages).WithOne(x => x.PartUsage)
                .HasForeignKey(x => x.PartUsageId).OnDelete(DeleteBehavior.Cascade);

            var line = modelBuilder.Entity<SparePartPartUsage>();
            line.HasOne<SparePart>().WithMany().HasForeignKey(x => x.SparePartId).OnDelete(DeleteBehavior.Restrict);
            line.HasIndex(x => new { x.PartUsageId, x.SparePartId }).IsUnique();
        }
    }
}
