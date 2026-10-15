using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class ComputerDbContext : DbContext
    {
        public DbSet<Computer> Computer => Set<Computer>();
        public DbSet<Campus> Campus => Set<Campus>();
        public DbSet<Building> Building => Set<Building>();
        public DbSet<Room> Room => Set<Room>();
        public DbSet<ComputerPhysicalLocation> ComputerPhysicalLocation => Set<ComputerPhysicalLocation>();
        public DbSet<ComputerPowerStatus> ComputerPowerStatus => Set<ComputerPowerStatus>();
        public DbSet<ComputerType> ComputerType => Set<ComputerType>();

        public ComputerDbContext(
            DbContextOptions<ComputerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComputerDbContext).Assembly);
        }
    }
}
