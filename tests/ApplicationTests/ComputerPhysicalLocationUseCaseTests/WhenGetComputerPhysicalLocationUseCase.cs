using application.Exceptions;
using application.UseCases.ComputerPhysicalLocationUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerPhysicalLocationUseCaseTests
{
    public class WhenGetComputerPhysicalLocationUseCase : IClassFixture<ComputerPhysicalLocationRepositoryDummy>
    {
        private readonly ComputerPhysicalLocationRepositoryDummy _computerPhysicalLocationRepositoryDummy;

        public WhenGetComputerPhysicalLocationUseCase(
            ComputerPhysicalLocationRepositoryDummy computerPhysicalLocationRepositoryDummy)
        {
            _computerPhysicalLocationRepositoryDummy = computerPhysicalLocationRepositoryDummy;
        }

        [Fact]
        public async Task WithValidPageAndPageSizeShouldReturnComputerPhysicalLocations()
        {
            // Arrange
            var useCase = new GetComputerPhysicalLocationUseCase(
                _computerPhysicalLocationRepositoryDummy);

            // Act
            var result = await useCase.ExecuteAsync(1, 10);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WithEmptyIdShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new GetComputerPhysicalLocationUseCase(
                _computerPhysicalLocationRepositoryDummy);

            // Act + Assert
            var exception = await Assert.ThrowsAsync<ApplicationLayerException>(
                async () => await useCase.ExecuteAsync(Guid.Empty));

            Assert.Equal(
                "Computer physical location id must be valid.",
                exception.Message);
        }

        [Fact]
        public async Task WithValidIdShouldNotThrowException()
        {
            // Arrange
            var id = Guid.NewGuid();

            var useCase = new GetComputerPhysicalLocationUseCase(_computerPhysicalLocationRepositoryDummy);

            // Act
            var exceptionRecorder = await Record.ExceptionAsync(async () =>
            {
                await useCase.ExecuteAsync(id);
            });
            var result = await useCase.ExecuteAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}