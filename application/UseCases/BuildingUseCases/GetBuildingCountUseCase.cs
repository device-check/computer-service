using application.Interfaces;

namespace application.UseCases.BuildingUseCases
{
    public class GetBuildingCountUseCase
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetBuildingCountUseCase(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _buildingRepository.CountAsync();
        }
    }
}
