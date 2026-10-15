using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.RoomUseCases
{
    public class DeleteRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task ExecuteAsync(Room room)
        {
            // pre-contract
            if (room is null)
                throw new ApplicationLayerException("Cannot delete a null room");

            await _roomRepository.DeleteAsync(room);
        }
    }
}
