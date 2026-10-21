using application.Exceptions;
using application.UseCases.RoomUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests
{
    public class WhenDeleteRoomUseCase : IClassFixture<RoomRepositoryDummy>
    {
        private readonly RoomRepositoryDummy _roomRepositoryDummy;

        public WhenDeleteRoomUseCase(RoomRepositoryDummy roomRepositoryDummy)
        {
            _roomRepositoryDummy = roomRepositoryDummy;
        }

        [Fact]
        public async Task WithNullRoomShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new DeleteRoomUseCase(
                _roomRepositoryDummy);

            // Act + Assert
            var exception = await Assert.ThrowsAsync<ApplicationLayerException>(
                async () => await useCase.ExecuteAsync(null!));
        }

        [Fact]
        public async Task WithValidRoomShouldNotThrowException()
        {
            // Arrange
            var room = new Room("Test");

            var useCase = new DeleteRoomUseCase(
                _roomRepositoryDummy);

            // Act
            var exception = await Record.ExceptionAsync(
                async () => await useCase.ExecuteAsync(room));

            // Assert
            Assert.Null(exception);
        }
    }
}