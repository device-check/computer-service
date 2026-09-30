using domain;
using domain.Entities;

namespace tests
{
    public class WhenSettingCampus
    {

        [Fact]
        public void WithNullCampusNameShouldThrowDomainException()
        {
            // Arrange
            string invalidCampusName = null;

            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Campus campus = new(invalidCampusName);
            });
        }

        [Fact]
        public void WithValidCampusNameShouldBeDefinedInUpperCaseFormat()
        {
            // Arrange
            string validCampusName = "sOUth ciTy";

            // Act
            Campus campus = new(validCampusName);

            // Assert
            Assert.True(campus.GetName() == validCampusName.ToUpper());
        }
    }
}
