using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ComputerDbContext _context;

        public RoomRepository(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Room room)
        {
            // pre-contract
            if (room is null)
                throw new InfrastructureLayerException("Cannot add a null room");

            await _context.Room.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Room.CountAsync();
        }

        public async Task DeleteAsync(Room room)
        {
            // pre-contract
            if (room is null)
                throw new InfrastructureLayerException("Cannot delete a null room");

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAsync(int page, int pageSize)
        {
            var room = await _context.Room
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return room;
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _context.Room
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => EF.Property<Guid>(c, "id_campus") == id);
        }
    }
}
