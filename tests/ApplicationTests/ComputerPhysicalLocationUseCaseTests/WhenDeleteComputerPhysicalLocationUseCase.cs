using application.Exceptions;
using application.UseCases.ComputerPhysicalLocationUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerPhysicalLocationUseCaseTests
{
    public class WhenDeleteComputerPhysicalLocationUseCase
        : IClassFixture<ComputerPhysicalLocationRepositoryDummy>
    {
        private readonly ComputerPhysicalLocationRepositoryDummy
            _computerPhysicalLocationRepositoryDummy;

        public WhenDeleteComputerPhysicalLocationUseCase(
            ComputerPhysicalLocationRepositoryDummy
                computerPhysicalLocationRepositoryDummy)
        {
            _computerPhysicalLocationRepositoryDummy =
                computerPhysicalLocationRepositoryDummy;
        }

        [Fact]
        public async Task WithEmptyIdComputerPhysicalLocationShouldThrowApplicationLayerException()
        {
            // Arrange          
            Guid empty_id_computer_physical_location = Guid.Empty;

            var useCase = new DeleteComputerPhysicalLocationUseCase(
                _computerPhysicalLocationRepositoryDummy);

            // Act + Assert
            var exception =
                await Assert.ThrowsAsync<ApplicationLayerException>(
                    () => useCase.ExecuteAsync(
                        empty_id_computer_physical_location));

            Assert.Equal(
                "Cannot delete a computer physical location with invalid ID.",
                exception.Message);
        }                

        [Fact]
        public async Task WithNotEmptyIdComputerPhysicalLocationShouldNotThrowException()
        {
            // Arrange
            Guid valid_id = Guid.NewGuid();
            var computerPhysicalLocation = new ComputerPhysicalLocation(valid_id, valid_id, 1, valid_id);

            var useCase = new DeleteComputerPhysicalLocationUseCase(
                _computerPhysicalLocationRepositoryDummy);

            // Act
            var exceptionRecorder = await Record.ExceptionAsync(async() => 
            {
                await useCase.ExecuteAsync(computerPhysicalLocation.GetId());
            });

            // Assert
            Assert.Null(exceptionRecorder);
        }
    }
}