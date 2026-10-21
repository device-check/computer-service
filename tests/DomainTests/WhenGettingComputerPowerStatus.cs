using domain.Entities;

namespace tests.DomainTests
{
    public class WhenGettingComputerPowerStatus
    {
        [Fact]
        public void ShouldReturnEmptyIdWhenStatusIsNotInitialized()
        {
            // Arrange
            ComputerPowerStatus powerStatus =
                (ComputerPowerStatus)Activator.CreateInstance(
                    typeof(ComputerPowerStatus),
                    nonPublic: true);

            // Act
            Guid result = powerStatus.GetId();

            // Assert
            Assert.Equal(Guid.Empty, result);
        }

        [Fact]
        public void ShouldReturnNullStatusWhenStatusIsNotInitialized()
        {
            // Arrange
            ComputerPowerStatus powerStatus =
                (ComputerPowerStatus)Activator.CreateInstance(
                    typeof(ComputerPowerStatus),
                    nonPublic: true);

            // Act
            string result = powerStatus.GetStatus();

            // Assert
            Assert.Null(result);
        }
    }
}