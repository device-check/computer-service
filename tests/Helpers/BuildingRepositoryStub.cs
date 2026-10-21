using application.Interfaces;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Helpers
{
    public class BuildingRepositoryStub : IBuildingRepository
    {
        public Task AddAsync(Building building)
        {
            return Task.CompletedTask;
        }

        public async Task<int> CountAsync()
        {
            return 0;
        }

        public Task DeleteAsync(Building building)
        {
            return Task.CompletedTask;
        }

        public async Task<List<Building>> GetAsync(int page, int pageSize)
        {
            return new List<Building>();
        }

        public async Task<Building?> GetByIdAsync(Guid id)
        {
            return null;
        }
    }
}
