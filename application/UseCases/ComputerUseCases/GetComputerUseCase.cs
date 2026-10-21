using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerUseCases
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

        public async Task<List<Computer>> ExecuteAsync(int page, int pageSize)
        {
            // pre-contract
            if (page == 0 || page < 0)
                throw new ApplicationLayerException("Page number must be greater than zero.");
            if (pageSize == 0 || pageSize < 0)
                throw new ApplicationLayerException("Page size number must be greater than zero.");

            return await _computerRepository.GetAsync(page, pageSize);
        }
    }
}
