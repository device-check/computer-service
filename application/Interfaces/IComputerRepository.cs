using domain.Entities;
using System.Net;
using System.Net.NetworkInformation;

namespace application.Interfaces
{
    public interface IComputerRepository
    {
        Task AddAsync(Computer computer);

        Task<Computer?> GetByIdAsync(Guid id_computer);

        Task<List<Computer>> GetAsync(int page, int pageSize);        

        Task DeleteAsync(Computer computer);        
        Task<bool> ExistsAsync(Computer computer);
        Task<int> CountAsync();
        Task UpdateAsync(Guid id, Guid? id_support, Guid? id_computer_physical_location, Guid? id_computer_type, Guid? id_computer_power_status, PhysicalAddress? computerMacAddress, IPAddress? computerIpv4Address);
    }
}