using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    internal class CampusConfiguration : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.ToTable("TableCampus");
            builder.HasKey("id_campus");

            // Campus.CampusName
            builder
                .Property<string>("_campusName")
                .HasColumnName("CampusName")
                .IsRequired();
            builder
                .HasIndex("_campusName")
                .IsUnique();
        }
    }
}
