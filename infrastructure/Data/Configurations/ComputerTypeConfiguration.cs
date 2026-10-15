using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    public class ComputerTypeConfiguration : IEntityTypeConfiguration<ComputerType>
    {
        public void Configure(EntityTypeBuilder<ComputerType> builder)
        {
            builder.ToTable("TableComputerType");
            builder.HasKey("id_computer_type");

            // ComputerType.ComputerTypeName
            builder
                .Property<string>("_computerTypeName")
                .HasColumnName("ComputerTypeName")
                .IsRequired();
            builder
                .HasIndex("_computerTypeName")
                .IsUnique();
        }
    }
}
