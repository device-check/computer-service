using interface_adapters.Dtos.Building;
using interface_adapters.Dtos.Campus;
using interface_adapters.Dtos.Room;

namespace interface_adapters.Dtos.ComputerPhysicalLocation
{
    public class ComputerPhysicalLocationReadDto
    {
        public required CampusReadDto Campus { get; set; }
        public required BuildingReadDto Building { get; set; }
        public required int Floor { get; set; }
        public required RoomReadDto Room { get; set; }
    }
}