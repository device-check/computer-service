using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerTypeUseCases
{
    public class GetComputerTypeUseCase
    {
        private readonly IComputerTypeRepository _computerTypeRepository;

        public GetComputerTypeUseCase(IComputerTypeRepository computerTypeRepository)
        {
            _computerTypeRepository = computerTypeRepository;
        }

        public async Task<List<ComputerType>> ExecuteAsync(int page, int pageSize)
        {
            return await _computerTypeRepository.GetAsync(page, pageSize);
        }
    }
}
