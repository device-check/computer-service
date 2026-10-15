using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    internal class ComputerPhysicalLocationConfiguration : IEntityTypeConfiguration<ComputerPhysicalLocation>
    {
        public void Configure(EntityTypeBuilder<ComputerPhysicalLocation> builder)
        {
            builder.ToTable("TableComputerPhysicalLocation");
            builder.HasKey("id_computer_physical_location");
            builder
                .HasIndex("id_campus", "id_building", "_floorNumber", "id_room")
                .IsUnique();


            // ComputerPhysicalLocation.FloorNumber
            builder
                .Property<int>("_floorNumber")
                .IsRequired();

            // ComputerPhysicalLocation <-> Campus
            builder
                .Property<Guid>("id_campus")
                .HasColumnName("id_campus");
            builder
                .HasOne<Campus>("_campus")
                .WithMany()
                .HasForeignKey("id_campus")
                .IsRequired();

            // ComputerPhysicalLocation <-> Building
            builder
                .Property<Guid>("id_building")
                .HasColumnName("id_building");
            builder
                .HasOne<Building>("_building")
                .WithMany()
                .HasForeignKey("id_building")
                .IsRequired();

            // ComputerPhysicalLocation <-> Building
            builder
                .Property<Guid>("id_building")
                .HasColumnName("id_building");
            builder
                .HasOne<Building>("_building")
                .WithMany()
                .HasForeignKey("id_building")
                .IsRequired();

            // ComputerPhysicalLocation <-> Room
            builder
                .Property<Guid>("id_room")
                .HasColumnName("id_room");
            builder
                .HasOne<Room>("_room")
                .WithMany()
                .HasForeignKey("id_room")
                .IsRequired();
        }
    }
}
