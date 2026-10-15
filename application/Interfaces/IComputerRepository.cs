using domain.Entities;

namespace application.Interfaces
{
    public interface IComputerRepository
    {
        Task AddAsync(Computer computer);

        Task<Computer?> GetByIdAsync(Guid id_computer);

        Task<List<Computer>> GetAsync(int page, int pageSize);

        Task UpdateAsync(Computer computer);

        Task DeleteAsync(Computer computer);        
        Task<bool> ExistsAsync(Computer computer);
        Task<int> CountAsync();
    }
}