using application.Interfaces;
using domain.Entities;
using shared_kernel.Exceptions.ApplicationLayerExceptions;

namespace application.UseCases.CampusUseCases
{
    public class UpdateCampusUseCase
    {
        private readonly ICampusRepository _campusRepository;

        public UpdateCampusUseCase(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }

        public async Task ExecuteAsync(Guid id, Campus campusModified)
        {
            //pre-contract
            if (Guid.Empty == id)
                throw new ApplicationLayerException("Cannot update a campus with invalid ID.");
            if (campusModified is null)
                throw new ApplicationLayerException("Cannot update a null campus.");

            await _campusRepository.UpdateAsync(id, campusModified);
        }
    }
}
