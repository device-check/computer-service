using application.Exceptions;
using application.UseCases.ComputerUseCases;
using domain.Entities;
using System.Net;
using System.Net.NetworkInformation;
using tests.Helpers;

namespace tests.ApplicationTests.ComputerUseCaseTests
{
    public class WhenUpdateComputerUseCase : IClassFixture<ComputerRepositoryDummy>
    {
        private readonly ComputerRepositoryDummy _computerRepositoryDummy;

        public WhenUpdateComputerUseCase(ComputerRepositoryDummy computerRepositoryDummy)
        {
            _computerRepositoryDummy = computerRepositoryDummy;
        }

        [Fact]
        public async Task WhenDoesntExistComputerModificationShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new UpdateComputerUseCase(
                _computerRepositoryDummy);
            Guid valid_computer_id = Guid.NewGuid();

            // Act + Assert
            var exception = await Assert.ThrowsAsync<ApplicationLayerException>(
                async () => await useCase.ExecuteAsync(valid_computer_id,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null));
        }        
    }
}