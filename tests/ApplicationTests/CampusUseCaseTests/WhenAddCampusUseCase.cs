using application.Exceptions;
using application.UseCases.CampusUseCases;
using domain.Entities;
using tests.Helpers;

namespace tests.ApplicationTests.CampusUseCaseTests
{
    public class WhenAddCampusUseCase : IClassFixture<CampusRepositoryStub>
    {
        private readonly CampusRepositoryStub _campusRepositoryStub;

        public WhenAddCampusUseCase(CampusRepositoryStub campusRepositoryStub)
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
                AddCampusUseCase addCampusUseCase =
                    new(_campusRepositoryStub);

                await addCampusUseCase.ExecuteAsync(nullCampus);
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
                AddCampusUseCase addCampusUseCase =
                    new(_campusRepositoryStub);

                await addCampusUseCase.ExecuteAsync(campus);
            });

            // Assert
            Assert.Null(recorderException);
        }
    }
}