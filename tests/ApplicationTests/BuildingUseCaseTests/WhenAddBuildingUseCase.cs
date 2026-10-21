using domain.Entities;
using application;
using application.Exceptions;
using application.UseCases.BuildingUseCases;
using tests.Helpers;

namespace tests.ApplicationTests.BuildingUseCaseTests
{
    public class WhenAddBuildingUseCase : IClassFixture<BuildingRepositoryStub>
    {
        private readonly BuildingRepositoryStub _buildingRepositoryStub;

        public WhenAddBuildingUseCase(BuildingRepositoryStub buildingRepositoryDummy)
        {
            _buildingRepositoryStub = buildingRepositoryDummy;
        }

        [Fact]
        public void WithNullBuildingShouldThrowApplicationLayerException()
        {
            // Arrange
            Building nullBuilding = null;

            // Act + Assert
            Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                AddBuildingUseCase addBuildingUseCase = new(_buildingRepositoryStub);
                await addBuildingUseCase.ExecuteAsync(nullBuilding);
            });
        }

        [Fact]
        public async void WithNotNullBuildingDontShouldThrowException()
        {
            // Arrange
            Building building = new("ficticious");

            // Act
            var recorderException = await Record.ExceptionAsync(async () =>
            {
                AddBuildingUseCase addBuildingUseCase = new(_buildingRepositoryStub);
                await addBuildingUseCase.ExecuteAsync(building);
            });

            // Assert
            Assert.Null(recorderException);
        }
    }
}
