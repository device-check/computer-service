using application.Interfaces;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Helpers
{
    public class ComputerTypeRepositoryDummy : IComputerTypeRepository
    {
        public async Task<int> CountAsync()
        {
            return await Task.FromResult(1);
        }

        public async Task<List<ComputerType>> GetAsync(int page, int pageSize)
        {
            return new List<ComputerType>();
        }
    }
}
