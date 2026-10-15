using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.RoomUseCases
{
    public class AddRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public AddRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task ExecuteAsync(Room room)
        {
            // pré-contract
            if (room is null)
                throw new ApplicationLayerException("Cannot add a null room");

            await _roomRepository.AddAsync(room);
        }
    }
}
