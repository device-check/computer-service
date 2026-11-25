using application.Interfaces;
using domain.Entities;

namespace tests.Helpers
{
    public class CampusRepositoryStub : ICampusRepository
    {
        public Task AddAsync(Campus campus)
        {
            return Task.CompletedTask;
        }

        public async Task<int> CountAsync()
        {
            return 0;
        }

        public Task DeleteAsync(Campus campus)
        {
            return Task.CompletedTask;
        }

        public async Task<List<Campus>> GetAsync(int page, int pageSize)
        {
            return new List<Campus>();
        }

        public async Task<Campus?> GetByIdAsync(Guid id)
        {
            return null;
        }

        public Task UpdateAsync(Guid id, Campus campusModified)
        {
            return Task.CompletedTask;
        }
    }
}