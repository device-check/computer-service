using application.Exceptions;
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
            // pre-contract
            if (page == 0 || page < 0)
                throw new ApplicationLayerException("Page number must be greater than zero.");
            if (pageSize == 0 || pageSize < 0)
                throw new ApplicationLayerException("Page size number must be greater than zero.");

            return await _campusRepository.GetAsync(page, pageSize);
        }

        public async Task<Campus?> ExecuteAsync(Guid id)
        {
            // pre-contract
            if (Guid.Empty == id)
                throw new ApplicationLayerException("Campus id must be valid.");

            return await _campusRepository.GetByIdAsync(id);
        }
    }
}
