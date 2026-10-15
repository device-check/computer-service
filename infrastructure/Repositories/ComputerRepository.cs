using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace infrastructure.Repositories
{
    public class ComputerRepository : IComputerRepository
    {

        private readonly ComputerDbContext _context;

        public ComputerRepository(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Computer computer)
        {
            // Pré-contract
            if (computer is null)
                throw new InfrastructureLayerException("Computer cannot be null to be added.");

            await _context.Computer.AddAsync(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Computer.CountAsync(); 
        }

        public async Task DeleteAsync(Computer computer)
        {
            // Pré-contract
            if (computer is null)
                throw new InfrastructureLayerException("Computer cannot be null to be deleted.");

            _context.Computer.Remove(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Computer computer)
        {
            // Pré-contract
            if (computer is null)
                throw new InfrastructureLayerException("Computer cannot be null to check existence.");

            bool computerWasFounded = await _context.Computer
                .AnyAsync(c => EF.Property<PhysicalAddress>(c, "_computerMacAddress") == computer.GetMacAddress());

            return computerWasFounded;
        }

        public Task<List<Computer>> GetAsync(int page, int pageSize)
        {
            // Pré-contract
            if (page <= 0)
                throw new InfrastructureLayerException("Page must be greater than zero.");
            if (pageSize <= 0)
                throw new InfrastructureLayerException("Page size must be greater than zero.");

            var computers = _context.Computer
                .AsNoTracking()                
                .Skip((page - 1) * pageSize)
                .Take(pageSize)                    
                .Include("_computerPowerStatus")
                .Include("_computerType")
                .Include("_computerPhysicalLocation")
                .Include("_computerPhysicalLocation._campus")
                .Include("_computerPhysicalLocation._building")
                .Include("_computerPhysicalLocation._room")
                .ToListAsync();

            return computers;
        }

        public async Task<Computer?> GetByIdAsync(Guid id_computer)
        {
            // Pré-contract
            if (Guid.Empty == id_computer)
                throw new InfrastructureLayerException("Id computer must be valid.");

            var computer = await _context.Computer                
                .Include("_computerPowerStatus")
                .Include("_computerType")
                .Include("_computerPhysicalLocation")
                .Include("_computerPhysicalLocation._campus")
                .Include("_computerPhysicalLocation._building")
                .Include("_computerPhysicalLocation._room")
                .FirstOrDefaultAsync(c => EF.Property<Guid>(c, "id_computer") == id_computer);

            return computer;            
        }

        public async Task UpdateAsync(Computer computer)
        {
            if (computer is null)
                throw new InfrastructureLayerException(
                    "Computer cannot be null to be updated.");

            var entry = _context.Entry(computer);

            if (entry.State == EntityState.Detached)
                throw new InfrastructureLayerException(
                    "Computer must be tracked by the DbContext to be updated.");

            await _context.SaveChangesAsync();
        }
    }
}
