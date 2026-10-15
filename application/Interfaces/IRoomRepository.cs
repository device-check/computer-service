using domain.Entities;

namespace application.Interfaces
{
    public interface IRoomRepository
    {
        Task AddAsync(Room room);
        Task<int> CountAsync();
        Task DeleteAsync(Room room);
        Task<List<Room>> GetAsync(int page, int pageSize);
        Task<Room> GetByIdAsync(Guid id);
    }
}