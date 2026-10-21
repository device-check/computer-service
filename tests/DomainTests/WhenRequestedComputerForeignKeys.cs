using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace tests.DomainTests
{
    public class WhenRequestedComputerForeignKeys
    {
        [Fact]
        public void WithAValidIdSupportAValidIdShouldBeReturned()
        {
            // Arrange
            Guid valid_foreign_key = Guid.NewGuid();
            IPAddress validIpv4Address = IPAddress.Parse("192.168.1.105"); // fictitious
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54"); // fictitious

            // Act
            Computer computer = new(
                valid_foreign_key, 
                valid_foreign_key, 
                valid_foreign_key, 
                valid_foreign_key, 
                validMacAddress, 
                validIpv4Address);

            var id_support = computer.GetIdSupport();

            // Assert
            Assert.NotEqual(Guid.Empty, id_support);
        }

        [Fact]
        public void WithAValidParametersAValidComputerIdShouldBeGenerated()
        {
            // Arrange
            Guid valid_foreign_key = Guid.NewGuid();
            IPAddress validIpv4Address = IPAddress.Parse("192.168.1.105"); // fictitious
            PhysicalAddress validMacAddress = PhysicalAddress.Parse("DC-A6-32-98-76-54"); // fictitious

            // Act
            Computer computer = new(
                valid_foreign_key,
                valid_foreign_key,
                valid_foreign_key,
                valid_foreign_key,
                validMacAddress,
                validIpv4Address);

            var id_computer = computer.GetId();

            // Assert
            Assert.NotEqual(Guid.Empty, id_computer);
        }
    }
}
