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

        public async Task ExecuteAsync(Guid id_computer)
        {
            // Pré-contract            
            if (Guid.Empty == id_computer)
                throw new ApplicationLayerException("Id computer cannot be null to be deleted.");           
            var computer = await _computerRepository.GetByIdAsync(id_computer);
            if (computer is null)
                throw new ApplicationLayerException("Computer not founded to be deleted.");

            await _computerRepository.DeleteAsync(computer);

            // Post-contract
            if (await _computerRepository.ExistsAsync(computer))
                throw new ApplicationLayerException("Error on deleting computer.");
        } 
    }
}
