using application.Interfaces;

namespace application.UseCases.RoomUseCases
{
    public class GetRoomCountUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomCountUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _roomRepository.CountAsync();
        }
    }
}
