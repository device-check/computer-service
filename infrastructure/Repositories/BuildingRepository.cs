using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ComputerDbContext _context;

        public BuildingRepository(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Building building)
        {
            // pre-contract
            if (building is null)
                throw new InfrastructureLayerException("Cannot add a null building");

            await _context.Building.AddAsync(building);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Building.CountAsync();
        }

        public async Task DeleteAsync(Building building)
        {
            // pre-contract
            if (building is null)
                throw new InfrastructureLayerException("Cannot delete a null building.");

            _context.Building.Remove(building);
            await _context.SaveChangesAsync();
        }

        public Task<List<Building>> GetAsync(int page, int pageSize)
        {
            return _context.Building
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Building?> GetByIdAsync(Guid id)
        {
            return await _context.Building
                .AsNoTracking()
                .FirstOrDefaultAsync(c => EF.Property<Guid>(c, "id_building") == id);
        }
    }
}
