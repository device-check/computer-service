using application.Exceptions;
using application.UseCases.RoomUseCases;
using tests.Helpers;

namespace tests.ApplicationTests
{
    public class WhenGetRoomUseCase : IClassFixture<RoomRepositoryDummy>
    {
        private readonly RoomRepositoryDummy _roomRepositoryDummy;

        public WhenGetRoomUseCase(RoomRepositoryDummy roomRepositoryDummy)
        {
            _roomRepositoryDummy = roomRepositoryDummy;
        }

        [Fact]
        public async Task WithValidPageAndPageSizeShouldReturnRooms()
        {
            // Arrange
            var useCase = new GetRoomUseCase(
                _roomRepositoryDummy);

            // Act
            var result = await useCase.ExecuteAsync(1, 10);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WithEmptyIdShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new GetRoomUseCase(
                _roomRepositoryDummy);

            // Act + Assert
            var exception = await Assert.ThrowsAsync<ApplicationLayerException>(
                async () => await useCase.ExecuteAsync(Guid.Empty));
        }

        [Fact]
        public async Task WithValidIdShouldNotThrowException()
        {
            // Arrange
            var useCase = new GetRoomUseCase(
                _roomRepositoryDummy);

            // Act
            var exception = await Record.ExceptionAsync(
                async () => await useCase.ExecuteAsync(Guid.NewGuid()));

            // Assert
            Assert.Null(exception);
        }
    }
}