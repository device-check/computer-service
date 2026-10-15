using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories
{
    public class CampusRepository : ICampusRepository
    {
        private readonly ComputerDbContext _context;

        public CampusRepository(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Campus campus)
        {
            // pré-contract
            if (campus is null)
                throw new InfrastructureLayerException("Cannot add null campus.");

            await _context.Campus.AddAsync(campus);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Campus.CountAsync();
        }

        public async Task DeleteAsync(Campus campus)
        {
            // pré-contract
            if (campus is null)
                throw new InfrastructureLayerException("Cannot delete null campus.");

            _context.Campus.Remove(campus);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Campus>> GetAsync(int page, int pageSize)
        {
            var campus = await _context.Campus
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return campus;
        }

        public async Task<Campus?> GetByIdAsync(Guid id)
        {
            //var campus = await _context.Campus
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(c => c.GetId() == id);

            //return campus;

            return await _context.Campus
        .AsNoTracking()
        .FirstOrDefaultAsync(
            c => EF.Property<Guid>(c, "id_campus") == id);
        }
    }
}
