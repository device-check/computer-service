using domain.Entities;

namespace application.Interfaces
{
    public interface ICampusRepository
    {
        Task AddAsync(Campus campus);
        Task<int> CountAsync();
        Task DeleteAsync(Campus campus);
        Task<List<Campus>> GetAsync(int page, int pageSize);
        Task<Campus?> GetByIdAsync(Guid id);
    }
}