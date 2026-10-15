using application.Interfaces;

namespace application.UseCases.ComputerUseCases
{
    public class GetComputerCountUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public GetComputerCountUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _computerRepository.CountAsync();
        }
    }
}
