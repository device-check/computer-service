using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Room
{
    public class RoomCreateDto
    {

        [Required(ErrorMessage="Room name is required.s")]
        public string Name { get; set; }
    }
}
