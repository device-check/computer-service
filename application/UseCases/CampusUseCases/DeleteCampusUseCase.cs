using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.CampusUseCases
{
    public class DeleteCampusUseCase
    {
        private readonly ICampusRepository _campusRepository;

        public DeleteCampusUseCase(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }

        public async Task ExecuteAsync(Campus campus)
        {
            // pré-contract
            if (campus is null)
                throw new ApplicationLayerException("Campus cannot be null");

            await _campusRepository.DeleteAsync(campus);
        }
    }
}
