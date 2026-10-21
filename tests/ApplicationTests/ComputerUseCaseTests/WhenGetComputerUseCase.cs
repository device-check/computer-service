using application.UseCases.ComputerUseCases;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerUseCaseTests
{
    public class WhenGetComputerUseCase : IClassFixture<ComputerRepositoryDummy>
    {
        private readonly ComputerRepositoryDummy _computerRepositoryDummy;

        public WhenGetComputerUseCase(ComputerRepositoryDummy computerRepositoryDummy)
        {
            _computerRepositoryDummy = computerRepositoryDummy;
        }

        [Fact]
        public async Task WithValidIdShouldReturnComputer()
        {
            // Arrange
            var useCase = new GetComputerUseCase(
                _computerRepositoryDummy);

            // Act
            var result = await useCase.ExecuteAsync(Guid.NewGuid());

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WithValidPageAndPageSizeShouldReturnComputers()
        {
            // Arrange
            var useCase = new GetComputerUseCase(
                _computerRepositoryDummy);

            // Act
            var result = await useCase.ExecuteAsync(1, 10);

            // Assert
            Assert.NotNull(result);
        }
    }
}