using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.CampusUseCases
{
    public class AddCampusUseCase
    {
        private readonly ICampusRepository _campusRepository;

        public AddCampusUseCase(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }

        public async Task ExecuteAsync(Campus campus)
        {
            // Pré-contract
            if (campus is null)
                throw new ApplicationLayerException("Campus cannot be null");

            await _campusRepository.AddAsync(campus);
        }
    }
}