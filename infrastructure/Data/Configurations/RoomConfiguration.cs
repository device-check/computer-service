using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("TableRoom");
            builder.HasKey("id_room");

            // Room.RoomName
            builder
                .Property<string>("_roomName")
                .HasColumnName("RoomName")
                .IsRequired();
            builder
                .HasIndex("_roomName")
                .IsUnique();
        }
    }
}
