using domain.Entities;
using application.UseCases.BuildingUseCases;
using tests.Helpers;
using shared_kernel.Exceptions.ApplicationLayerExceptions;

namespace tests.ApplicationTests.BuildingUseCaseTests
{
    public class WhenDeleteBuildingUseCase : IClassFixture<BuildingRepositoryStub>
    {
        private readonly BuildingRepositoryStub _buildingRepositoryStub;

        public WhenDeleteBuildingUseCase(BuildingRepositoryStub buildingRepositoryStub)
        {
            _buildingRepositoryStub = buildingRepositoryStub;
        }

        [Fact]
        public async Task WithNullBuildingShouldThrowApplicationLayerException()
        {
            // Arrange
            Building nullBuilding = null;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                DeleteBuildingUseCase deleteBuildingUseCase = new(_buildingRepositoryStub);
                await deleteBuildingUseCase.ExecuteAsync(nullBuilding);
            });
        }

        [Fact]
        public async Task WithNotNullBuildingDontShouldThrowException()
        {
            // Arrange
            Building building = new("ficticious");

            // Act
            var recorderException = await Record.ExceptionAsync(async () =>
            {
                DeleteBuildingUseCase deleteBuildingUseCase = new(_buildingRepositoryStub);
                await deleteBuildingUseCase.ExecuteAsync(building);
            });

            // Assert
            Assert.Null(recorderException);
        }
    }
}