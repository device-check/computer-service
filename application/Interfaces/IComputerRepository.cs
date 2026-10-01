using domain.Entities;

namespace application.Interfaces
{
    public interface IComputerRepository
    {
        Task AddAsync(Computer computer);

        Task<Computer?> GetByIdAsync(Guid id_computer);

        Task<IEnumerable<Computer>> GetAllAsync();

        Task UpdateAsync(Computer computer);

        Task DeleteAsync(Computer computer);        
        Task<bool> ExistsAsync(Computer computer);
    }
}