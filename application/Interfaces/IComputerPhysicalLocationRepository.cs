using domain.Entities;

namespace application.Interfaces
{
    public interface IComputerPhysicalLocationRepository
    {
        Task AddAsync(ComputerPhysicalLocation computerPhysicalLocation);
        Task<int> CountAsync();
        Task DeleteAsync(ComputerPhysicalLocation computerPhysicalLocation);
        Task<List<ComputerPhysicalLocation>> GetAsync(int page, int pageSize);
        Task<ComputerPhysicalLocation> GetByIdAsync(Guid id);
    }
}