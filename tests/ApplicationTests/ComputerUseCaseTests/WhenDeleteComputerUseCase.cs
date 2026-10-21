using application.Exceptions;
using application.UseCases.ComputerUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerUseCaseTests
{
    public class WhenDeleteComputerUseCase : IClassFixture<ComputerRepositoryDummy>
    {
        private readonly ComputerRepositoryDummy _computerRepositoryDummy;

        public WhenDeleteComputerUseCase(ComputerRepositoryDummy computerRepositoryDummy)
        {
            _computerRepositoryDummy = computerRepositoryDummy;
        }

        [Fact]
        public async Task WithEmptyIdShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new DeleteComputerUseCase(_computerRepositoryDummy);

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () => await useCase.ExecuteAsync(Guid.Empty));            
        }

        [Fact]
        public async Task WithValidIdShouldNotThrowException()
        {
            // Arrange
            Guid valid_id = Guid.NewGuid();
            var useCase = new DeleteComputerUseCase(_computerRepositoryDummy);

            // Act
            var exceptionRecorder = await Record.ExceptionAsync(async () =>
            {
                await useCase.ExecuteAsync(valid_id);
            });

            // Assert
            Assert.Null(exceptionRecorder);
        }
    }
}