using domain.Entities;

namespace application.Interfaces
{
    public interface IBuildingRepository
    {
        Task AddAsync(Building building);
        Task<int> CountAsync();
        Task DeleteAsync(Building building);
        Task<List<Building>> GetAsync(int page, int pageSize);
        Task<Building?> GetByIdAsync(Guid id);
    }
}