using application.Interfaces;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace tests.Helpers
{
    public class ComputerRepositoryDummy : IComputerRepository
    {
        public Task AddAsync(Computer computer)
        {
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult(1);
        }

        public Task DeleteAsync(Computer computer)
        {
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(Computer computer)
        {
            return Task.FromResult(false);
        }

        public async Task<List<Computer>> GetAsync(int page, int pageSize)
        {
            return new List<Computer>();
        }

        public async Task<Computer?> GetByIdAsync(Guid id_computer)
        {
            Guid ficticious_id = Guid.NewGuid();
            PhysicalAddress ficticiousMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54");
            IPAddress ficticiousIpv4 = IPAddress.Parse("192.168.0.1");
            return new Computer(
                ficticious_id, 
                ficticious_id, 
                ficticious_id, 
                ficticious_id, 
                ficticiousMacAddress, 
                ficticiousIpv4);
        }

        public Task UpdateAsync(Guid id, Guid? id_support, Guid? id_computer_physical_location, Guid? id_computer_type, Guid? id_computer_power_status, PhysicalAddress? computerMacAddress, IPAddress? computerIpv4Address)
        {
            return Task.CompletedTask;
        }
    }
}
