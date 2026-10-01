using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases
{
    public class AddComputerUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public AddComputerUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task ExecuteAsync(Computer computer)
        {
            // Pré-contract
            if (computer is null)
                throw new ApplicationLayerException("For adding action, computer cannot be null");

            await _computerRepository.AddAsync(computer);

            // Post-contract
            if (!await _computerRepository.ExistsAsync(computer))
                throw new ApplicationLayerException("Error to add a computer.");
        }
    }
}
