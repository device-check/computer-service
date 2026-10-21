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
        public async Task WithNullComputerShouldThrowApplicationLayerException()
        {
            // Arrange
            var useCase = new UpdateComputerUseCase(
                _computerRepositoryDummy);

            // Act + Assert
            var exception = await Assert.ThrowsAsync<ApplicationLayerException>(
                async () => await useCase.ExecuteAsync(null!));
        }

        [Fact]
        public async Task WithValidComputerShouldNotThrowException()
        {
            // Arrange
            Guid valid_id = Guid.NewGuid();
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54");
            IPAddress validIpAdress = IPAddress.Parse("192.168.0.0");
            var computer = new Computer(
                valid_id,
                valid_id,
                valid_id,
                valid_id,
                validMacAddress,
                validIpAdress);            

            var useCase = new UpdateComputerUseCase(_computerRepositoryDummy);

            // Act
            var exception = await Record.ExceptionAsync(async () => await useCase.ExecuteAsync(computer));

            // Assert
            Assert.Null(exception);
        }
    }
}