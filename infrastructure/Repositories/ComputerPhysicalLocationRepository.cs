using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories
{
    public class ComputerPhysicalLocationRepository : IComputerPhysicalLocationRepository
    {
        private readonly ComputerDbContext _context;

        public ComputerPhysicalLocationRepository(ComputerDbContext computerDbContext)
        {
            _context = computerDbContext;
        }

        public async Task AddAsync(
            ComputerPhysicalLocation computerPhysicalLocation)
        {
            if (computerPhysicalLocation is null)
                throw new InfrastructureLayerException("Cannot add a null computer physical location.");

            await _context.ComputerPhysicalLocation
                .AddAsync(computerPhysicalLocation);

            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.ComputerPhysicalLocation
                .CountAsync();
        }

        public async Task DeleteAsync(
            ComputerPhysicalLocation computerPhysicalLocation)
        {
            if (computerPhysicalLocation is null)
                throw new InfrastructureLayerException("Cannot delete a null computer physical location.");

            _context.ComputerPhysicalLocation
                .Remove(computerPhysicalLocation);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ComputerPhysicalLocation>> GetAsync(
            int page,
            int pageSize)
        {
            if (page < 1)
                throw new InfrastructureLayerException("Page number must be bigger 0.");

            if (pageSize < 1)
                throw new InfrastructureLayerException("Page size must be bigger 0.");

            return await _context.ComputerPhysicalLocation
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include("_campus")
                .Include("_building")
                .Include("_room")
                .ToListAsync();
        }

        public async Task<ComputerPhysicalLocation?> GetByIdAsync(Guid id)
        {
            return await _context.ComputerPhysicalLocation
                .AsNoTracking()
                .Include("_campus")
                .Include("_building")
                .Include("_room")
                .FirstOrDefaultAsync(c => EF.Property<Guid>(c, "id_computer_physical_location") == id);
        }
    }
}