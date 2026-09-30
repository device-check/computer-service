using domain;
using domain.Entities;
using System.Net;
using System.Net.NetworkInformation;

namespace tests
{
    public class WhenSettingComputerForeignKeys
    {
        [Theory]
        [InlineData(null)]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void WithInvalidIdSupportShouldThrowDomainException(Guid invalid_foreign_key)
        {
            // Arrange
            Guid valid_foreign_key = Guid.NewGuid();
            IPAddress validIpv4Address = IPAddress.Parse("192.168.1.105"); // fictitious
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54"); // fictitious


            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    valid_foreign_key,
                    invalid_foreign_key,
                    valid_foreign_key,
                    validMacAddress,
                    validIpv4Address);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void WithInvalidIdComputerTypeShouldThrowDomainException(Guid invalid_foreign_key)
        {
            // Arrange
            Guid valid_foreign_key = Guid.NewGuid();
            IPAddress validIpv4Address = IPAddress.Parse("192.168.1.105"); // fictitious
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54"); // fictitious


            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    invalid_foreign_key,
                    valid_foreign_key,
                    valid_foreign_key,
                    validMacAddress,
                    validIpv4Address);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void WithInvalidIdComputerPhysicalLocationShouldThrowDomainException(Guid invalid_foreign_key)
        {
            // Arrange
            Guid valid_foreign_key = Guid.NewGuid();
            IPAddress validIpv4Address = IPAddress.Parse("192.168.1.105"); // fictitious
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54"); // fictitious


            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    valid_foreign_key,
                    valid_foreign_key,
                    invalid_foreign_key,
                    validMacAddress,
                    validIpv4Address);
            });
        }
    }
}
