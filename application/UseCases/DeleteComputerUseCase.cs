using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases
{
    public class DeleteComputerUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public DeleteComputerUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task ExecuteAsync(Computer computer)
        {
            // Pré-contract
            if (!await _computerRepository.ExistsAsync(computer))
                throw new ApplicationLayerException("Computer don't finded to be deleted.");

            await _computerRepository.DeleteAsync(computer);

            // Post-contract
            if (await _computerRepository.ExistsAsync(computer))
                throw new ApplicationLayerException("Error on deleting computer.");
        } 
    }
}
