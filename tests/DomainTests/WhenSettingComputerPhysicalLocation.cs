using domain.Entities;
using domain.Exceptions;

namespace tests.DomainTests
{
    public class WhenSettingComputerPhysicalLocation
    {
        [Fact]
        public void WithValidDataShouldCreateComputerPhysicalLocation()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 2;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.NotEqual(Guid.Empty, location.GetId());
            Assert.Equal(floorNumber, location.GetFloor());
        }

        [Fact]
        public void WithEmptyCampusIdShouldThrowDomainException()
        {
            // Arrange
            Guid idCampus = Guid.Empty;
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 2;
            Guid idRoom = Guid.NewGuid();

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                ComputerPhysicalLocation location = new(
                    idCampus,
                    idBuilding,
                    floorNumber,
                    idRoom);
            });
        }

        [Fact]
        public void WithEmptyBuildingIdShouldThrowDomainException()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.Empty;
            int floorNumber = 2;
            Guid idRoom = Guid.NewGuid();

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                ComputerPhysicalLocation location = new(
                    idCampus,
                    idBuilding,
                    floorNumber,
                    idRoom);
            });
        }

        [Fact]
        public void WithEmptyRoomIdShouldThrowDomainException()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 2;
            Guid idRoom = Guid.Empty;

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                ComputerPhysicalLocation location = new(
                    idCampus,
                    idBuilding,
                    floorNumber,
                    idRoom);
            });
        }

        [Fact]
        public void WithValidDataShouldReturnTheDefinedFloor()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 5;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.Equal(floorNumber, location.GetFloor());
        }

        [Fact]
        public void WithValidDataShouldGenerateANonEmptyId()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 1;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.NotEqual(Guid.Empty, location.GetId());
        }

        [Fact]
        public void WithValidDataShouldReturnNullCampusUntilRelationshipIsLoaded()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 1;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.Null(location.GetCampus());
        }

        [Fact]
        public void WithValidDataShouldReturnNullBuildingUntilRelationshipIsLoaded()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 1;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.Null(location.GetBuilding());
        }

        [Fact]
        public void WithValidDataShouldReturnNullRoomUntilRelationshipIsLoaded()
        {
            // Arrange
            Guid idCampus = Guid.NewGuid();
            Guid idBuilding = Guid.NewGuid();
            int floorNumber = 1;
            Guid idRoom = Guid.NewGuid();

            // Act
            ComputerPhysicalLocation location = new(
                idCampus,
                idBuilding,
                floorNumber,
                idRoom);

            // Assert
            Assert.Null(location.GetRoom());
        }
    }
}