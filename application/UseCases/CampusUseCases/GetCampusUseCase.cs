using application.Interfaces;
using domain.Entities;

namespace application.UseCases.CampusUseCases
{
    public class GetCampusUseCase
    {
        private readonly ICampusRepository _campusRepository;

        public GetCampusUseCase(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }

        public async Task<List<Campus>> ExecuteAsync(int page, int pageSize)
        {
            return await _campusRepository.GetAsync(page, pageSize);
        }

        public async Task<Campus?> ExecuteAsync(Guid id)
        {
            return await _campusRepository.GetByIdAsync(id);
        }
    }
}
