using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerUseCases
{
    public class UpdateComputerUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public UpdateComputerUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task ExecuteAsync(Computer computer)
        {
            // Pre-contract
            if (computer is null)
                throw new ApplicationLayerException("To be updated, computer cannot be null");            

            await _computerRepository.UpdateAsync(computer); 
        }
    }
}
