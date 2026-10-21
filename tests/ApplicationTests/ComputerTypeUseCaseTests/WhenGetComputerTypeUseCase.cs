using application.UseCases.ComputerTypeUseCases;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerTypeUseCaseTests
{
    public class WhenGetComputerTypeUseCase : IClassFixture<ComputerTypeRepositoryDummy>
    {
        private readonly ComputerTypeRepositoryDummy _computerTypeRepositoryDummy;

        public WhenGetComputerTypeUseCase(
            ComputerTypeRepositoryDummy computerTypeRepositoryDummy)
        {
            _computerTypeRepositoryDummy = computerTypeRepositoryDummy;
        }

        [Fact]
        public async Task WithValidPageAndPageSizeShouldReturnComputerTypes()
        {
            // Arrange
            var useCase = new GetComputerTypeUseCase(
                _computerTypeRepositoryDummy);

            // Act
            var result = await useCase.ExecuteAsync(1, 10);

            // Assert
            Assert.NotNull(result);
        }
    }
}