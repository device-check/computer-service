using domain.Entities;

namespace application.Interfaces
{
    public interface IComputerPhysicalLocationRepository
    {
        Task AddAsync(ComputerPhysicalLocation computerPhysicalLocation);
        Task<int> CountAsync();
        Task DeleteAsync(Guid id);
        Task<List<ComputerPhysicalLocation>> GetAsync(int page, int pageSize);
        Task<ComputerPhysicalLocation> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, Guid? id_campus, Guid? id_building, int? floorNumber, Guid? id_room);
    }
}