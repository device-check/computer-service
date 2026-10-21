using application.Interfaces;
using domain.Entities;

namespace tests.Helpers
{
    public class RoomRepositoryDummy : IRoomRepository
    {
        public Task AddAsync(Room room)
        {
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult(1);
        }

        public Task DeleteAsync(Room room)
        {
            return Task.CompletedTask;
        }

        public async Task<List<Room>> GetAsync(int page, int pageSize)
        {
            return new List<Room>();
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return null;
        }
    }
}
