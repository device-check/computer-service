using application.Interfaces;
using domain.Entities;

namespace application.UseCases
{
    public class GetComputerUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public GetComputerUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task<Computer?> ExecuteAsync(Guid id_computer)
        {
            return await _computerRepository.GetByIdAsync(id_computer);
        }

        public async Task<IEnumerable<Computer>> ExecuteAsync()
        {
            return await _computerRepository.GetAllAsync();
        }
    }
}
