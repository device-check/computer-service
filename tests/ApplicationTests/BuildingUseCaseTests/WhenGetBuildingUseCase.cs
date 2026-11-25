using application.UseCases.BuildingUseCases;
using shared_kernel.Exceptions.ApplicationLayerExceptions;
using tests.Helpers;

namespace tests.ApplicationTests.BuildingUseCaseTests
{
    public class WhenGetBuildingUseCase : IClassFixture<BuildingRepositoryStub>
    {
        private readonly BuildingRepositoryStub _buldingRepositoryStub;

        public WhenGetBuildingUseCase(BuildingRepositoryStub buldingRepositoryStub)
        {
            _buldingRepositoryStub = buldingRepositoryStub;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void WithPageNumberEqualsZeroOrPageNumberLessThenZeroShouldThrowException(int page)
        {
            // Arrange
            int pageSize = 10;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                GetBuildingUseCase getBuildingUseCase = new(_buldingRepositoryStub);
                await getBuildingUseCase.ExecuteAsync(page, pageSize);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void WithPageSizeNumberEqualsZeroOrPageNumberLessThenZeroShouldThrowException(int pageSize)
        {
            // Arrange
            int page = 1;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                GetBuildingUseCase getBuildingUseCase = new(_buldingRepositoryStub);
                await getBuildingUseCase.ExecuteAsync(page, pageSize);
            });
        }

        [Fact]
        public async void WithEmptyIdShouldThrowException()
        {
            // Arrange
            Guid id = Guid.Empty;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async() =>
            {
                GetBuildingUseCase getBuildingUseCase = new(_buldingRepositoryStub);
                await getBuildingUseCase.ExecuteAsync(id);
            });
        }
    }
}
