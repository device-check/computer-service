using application.Exceptions;
using application.UseCases.CampusUseCases;
using tests.Helpers;

namespace tests.ApplicationTests.CampusUseCaseTests
{
    public class WhenGetCampusUseCase : IClassFixture<CampusRepositoryStub>
    {
        private readonly CampusRepositoryStub _campusRepositoryStub;

        public WhenGetCampusUseCase(CampusRepositoryStub campusRepositoryStub)
        {
            _campusRepositoryStub = campusRepositoryStub;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task WithPageNumberIsLessThanZeroOrEqualsThanZeroShouldThrowException(int page) 
        {
            // Arrange
            GetCampusUseCase getCampusUseCase = new(_campusRepositoryStub);
            int pageSize = 10;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async() =>
            {
                await getCampusUseCase.ExecuteAsync(page, pageSize);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task WithPageSizeNumberIsLessThanZeroOrEqualsThanZeroShouldThrowException(int pageSize)
        {
            // Arrange
            GetCampusUseCase getCampusUseCase = new(_campusRepositoryStub);
            int page = 1;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                await getCampusUseCase.ExecuteAsync(page, pageSize);
            });
        }

        [Fact]
        public async Task WithPageAndPageSizeShouldReturnCampusList()
        {
            // Arrange
            GetCampusUseCase getCampusUseCase =
                new(_campusRepositoryStub);

            int page = 1;
            int pageSize = 10;

            // Act
            var result = await getCampusUseCase.ExecuteAsync(page, pageSize);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WithEmptyIdShouldThrowException()
        {
            // Arrange
            GetCampusUseCase getCampusUseCase = new(_campusRepositoryStub);
            Guid id = Guid.Empty;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async() =>
            {
                await getCampusUseCase.ExecuteAsync(id);
            });
        }
    }
}