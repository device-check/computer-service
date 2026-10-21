using application.Exceptions;
using application.UseCases.CampusUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests.CampusUseCaseTests
{
    public class WhenDeleteCampusUseCase : IClassFixture<CampusRepositoryStub>
    {
        private readonly CampusRepositoryStub _campusRepositoryStub;

        public WhenDeleteCampusUseCase(CampusRepositoryStub campusRepositoryStub)
        {
            _campusRepositoryStub = campusRepositoryStub;
        }

        [Fact]
        public async Task WithNullCampusShouldThrowApplicationLayerException()
        {
            // Arrange
            Campus nullCampus = null;

            // Act + Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(async () =>
            {
                DeleteCampusUseCase deleteCampusUseCase =
                    new(_campusRepositoryStub);

                await deleteCampusUseCase.ExecuteAsync(nullCampus);
            });
        }

        [Fact]
        public async Task WithNotNullCampusShouldNotThrowException()
        {
            // Arrange
            Campus campus = new("ficticious");

            // Act
            var recorderException = await Record.ExceptionAsync(async () =>
            {
                DeleteCampusUseCase deleteCampusUseCase =
                    new(_campusRepositoryStub);

                await deleteCampusUseCase.ExecuteAsync(campus);
            });

            // Assert
            Assert.Null(recorderException);
        }
    }
}