using application.Interfaces;
using domain.Entities;

namespace tests.Helpers
{
    public class ComputerPhysicalLocationRepositoryDummy
        : IComputerPhysicalLocationRepository
    {
        public Task AddAsync(ComputerPhysicalLocation computerPhysicalLocation)
        {
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult(0);
        }

        public Task DeleteAsync(ComputerPhysicalLocation computerPhysicalLocation)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task<List<ComputerPhysicalLocation>> GetAsync(
            int page,
            int pageSize)
        {
            return Task.FromResult(
                new List<ComputerPhysicalLocation>());
        }

        public Task<ComputerPhysicalLocation?> GetByIdAsync(Guid id)
        {
            return Task.FromResult<ComputerPhysicalLocation?>(null);
        }

        public Task UpdateAsync(Guid id, Guid? id_campus, Guid? id_building, int? floorNumber, Guid? id_room)
        {
            return Task.CompletedTask;
        }
    }
}