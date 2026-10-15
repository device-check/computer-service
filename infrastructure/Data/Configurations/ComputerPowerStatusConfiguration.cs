using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    internal class ComputerPowerStatusConfiguration : IEntityTypeConfiguration<ComputerPowerStatus>
    {
        public void Configure(EntityTypeBuilder<ComputerPowerStatus> builder)
        {
            builder.ToTable("TableComputerPowerStatus");
            builder.HasKey("id_computer_power_status");

            // ComputerPowerStatus.StatusName
            builder
                .Property<string>("_statusName")
                .HasColumnName("StatusName")
                .IsRequired();
            builder
                .HasIndex("_statusName")
                .IsUnique();
        }
    }
}
