using domain;
using domain.Entities;

namespace tests
{
    public class WhenSettingRoom
    {

        [Fact]
        public void WithNullRoomNameShouldThrowDomainException()
        {
            // Arrange
            string invalidRoomName = null;

            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Room room = new(invalidRoomName);
            });
        }

        [Fact]
        public void WithValidRoomNameShouldBeDefinedInUpperCaseFormat()
        {
            // Arrange
            string validRoomName = "teChnoloGY rOom";

            // Act
            Room room = new(validRoomName);

            // Assert
            Assert.True(room.GetName() == validRoomName.ToUpper());
        }
    }
}
