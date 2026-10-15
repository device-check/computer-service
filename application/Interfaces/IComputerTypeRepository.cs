using domain.Entities;

namespace application.Interfaces
{
    public interface IComputerTypeRepository
    {
        Task<int> CountAsync();
        Task<List<ComputerType>> GetAsync(int page, int pageSize);
    }
}