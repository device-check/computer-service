using application.Interfaces;

namespace application.UseCases.CampusUseCases
{
    public class GetCampusCountUseCase
    {
        private ICampusRepository _campusRepository;

        public GetCampusCountUseCase(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _campusRepository.CountAsync();
        }
    }
}
