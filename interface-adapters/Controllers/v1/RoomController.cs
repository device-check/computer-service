using application.Exceptions;
using application.UseCases.RoomUseCases;
using Asp.Versioning;
using domain.Entities;
using interface_adapters.Dtos.Building;
using interface_adapters.Dtos.Room;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;

namespace interface_adapters.Controllers.v1
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly AddRoomUseCase _addRoomUseCase;
        private readonly GetRoomUseCase _getRoomUseCase;
        private readonly DeleteRoomUseCase _deleteRoomUseCase;
        private readonly GetRoomCountUseCase _getRoomCountUseCase;

        public RoomController(AddRoomUseCase addRoomUseCase, GetRoomUseCase getRoomUseCase, DeleteRoomUseCase deleteRoomUseCase, GetRoomCountUseCase getRoomCountUseCase)
        {
            _addRoomUseCase = addRoomUseCase;
            _getRoomUseCase = getRoomUseCase;
            _deleteRoomUseCase = deleteRoomUseCase;
            _getRoomCountUseCase = getRoomCountUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<RoomReadDto>>>> ListAsync(
            [FromQuery] int page=1, 
            [FromQuery] int pageSize = 10)
        {
            var rooms = await _getRoomUseCase.ExecuteAsync(page, pageSize);
            var roomsDto = rooms.Select(r => new RoomReadDto
            {
                Name = r.GetName()
            }).ToList();

            int roomCount = await _getRoomCountUseCase.ExecuteAsync();
            int totalPages = (int)Math.Ceiling((double)roomCount / pageSize);

            return Ok(new ApiResponse<List<RoomReadDto>>
            {
                Data = roomsDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalItems = roomCount,
                        TotalPages = totalPages
                    }
                }
            });
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse<RoomReadDto>>> ListByIdAsync(Guid id)
        {
            var room = await _getRoomUseCase.ExecuteAsync(id);
            if (room is null)
                return NotFound();

            var roomDto = new RoomReadDto { Name = room.GetName() };

            return Ok(new ApiResponse<RoomReadDto>
            {
                Data = roomDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage = 1,
                        PageSize = 1,
                        TotalItems = 1,
                        TotalPages = 1
                    }
                }
            });
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] RoomCreateDto roomCreateDto)
        {
            var room = new Room(roomCreateDto.Name);
            await _addRoomUseCase.ExecuteAsync(room);
            var roomReadDto = new RoomReadDto
            {
                Name = room.GetName()
            };

            return CreatedAtRoute(
                nameof(ListByIdAsync),
                new
                {
                    id = room.GetId()
                },
                roomReadDto);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var room = await _getRoomUseCase.ExecuteAsync(id);
            if (room is null)
                return NotFound();

            await _deleteRoomUseCase.ExecuteAsync(room);

            return NoContent();
        }
    }
}
