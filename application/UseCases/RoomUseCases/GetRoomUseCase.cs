using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.RoomUseCases
{
    public class GetRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<Room>> ExecuteAsync(int page, int pageSize)
        {
            return await _roomRepository.GetAsync(page, pageSize);
        }

        public async Task<Room?> ExecuteAsync(Guid id)
        {
            // pre-contract
            if (id == Guid.Empty)
                throw new ApplicationLayerException("Room id must be valid.");

            return await _roomRepository.GetByIdAsync(id);
        }
    }
}
