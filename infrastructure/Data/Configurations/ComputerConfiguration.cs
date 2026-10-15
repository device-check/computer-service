using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using System.Net.NetworkInformation;

namespace infrastructure.Data.Configurations
{
    public class ComputerConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.ToTable("TableComputer");
            builder.HasKey("id_computer");

            // Computer.ComputerMacAddress
            builder
                .Property<PhysicalAddress>("_computerMacAddress")
                .HasColumnName("ComputerMacAddress")
                .HasConversion(
                mac => mac.ToString(),
                mac => PhysicalAddress.Parse(mac))
                .IsRequired();
            builder
                .HasIndex("_computerMacAddress")
                .IsUnique();

            // Computer.ComputerIpv4Address
            builder
                .Property<IPAddress>("_computerIpv4Address")
                .HasColumnName("ComputerIpv4Address")
                .HasConversion(
                ipv4 => ipv4.ToString(), 
                ipv4 => IPAddress.Parse(ipv4))
                .IsRequired();
            builder
                .HasIndex("_computerIpv4Address")
                .IsUnique();


            // Computer <-> ComputerType
            builder
                .Property<Guid>("id_computer_type")
                .HasColumnName("id_computer_type");
            builder
                .HasOne<ComputerType>("_computerType")
                .WithMany()
                .HasForeignKey("id_computer_type")
                .IsRequired();

            // Computer <-> ComputerPhysicalLocation
            builder
                .Property<Guid>("id_computer_physical_location")
                .HasColumnName("id_computer_physical_location");
            builder
                .HasOne<ComputerPhysicalLocation>("_computerPhysicalLocation")
                .WithMany()
                .HasForeignKey("id_computer_physical_location")
                .IsRequired();

            // Computer <-> ComputerPowerStatus
            builder
                .Property<Guid>("id_computer_power_status")
                .HasColumnName("id_computer_power_status");
            builder
                .HasOne<ComputerPowerStatus>("_computerPowerStatus")
                .WithMany()
                .HasForeignKey("id_computer_power_status")
                .IsRequired();

            // Computer <-> Support
            builder
                .Property<Guid>("id_support")
                .HasColumnName("id_support")
                .IsRequired();          
        }
    }
}
