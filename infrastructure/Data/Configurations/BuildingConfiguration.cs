using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    internal class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("TableBuilding");
            builder.HasKey("id_building");

            // Building.BuildingName
            builder
                .Property<string>("_buildingName")
                .HasColumnName("BuildingName")
                .IsRequired();
            builder
                .HasIndex("_buildingName")
                .IsUnique();
        }
    }
}
