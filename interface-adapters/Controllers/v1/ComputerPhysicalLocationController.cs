using application.UseCases.ComputerPhysicalLocationUseCases;
using Asp.Versioning;
using domain.Entities;
using interface_adapters.Dtos.Building;
using interface_adapters.Dtos.ComputerPhysicalLocation;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;

namespace interface_adapters.Controllers.v1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ComputerPhysicalLocationController : ControllerBase
    {
        private readonly AddComputerPhysicalLocationUseCase _addComputerPhysicalLocationUseCase;
        private readonly GetComputerPhysicalLocationUseCase _getComputerPhysicalLocationUseCase;
        private readonly DeleteComputerPhysicalLocationUseCase _deleteComputerPhysicalLocationUseCase;
        private readonly GetComputerPhysicalLocationCountUseCase _getComputerPhysicalLocationCountUseCase;

        public ComputerPhysicalLocationController(
            AddComputerPhysicalLocationUseCase addComputerPhysicalLocationUseCase,
            GetComputerPhysicalLocationUseCase getComputerPhysicalLocationUseCase,
            DeleteComputerPhysicalLocationUseCase deleteComputerPhysicalLocationUseCase,
            GetComputerPhysicalLocationCountUseCase getComputerPhysicalLocationCountUseCase)
        {
            _addComputerPhysicalLocationUseCase = addComputerPhysicalLocationUseCase;
            _getComputerPhysicalLocationUseCase = getComputerPhysicalLocationUseCase;
            _deleteComputerPhysicalLocationUseCase = deleteComputerPhysicalLocationUseCase;
            _getComputerPhysicalLocationCountUseCase = getComputerPhysicalLocationCountUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ComputerPhysicalLocationReadDto>>>> ListAsync(
            [FromQuery] int page=1,
            [FromQuery] int pageSize = 10)
        {
            var computerPhysicalLocations = await _getComputerPhysicalLocationUseCase.ExecuteAsync(page, pageSize);
            var computerPhysicalLocationsDto = computerPhysicalLocations
                .Select(cpl => new ComputerPhysicalLocationReadDto
                {
                    Campus = new() { Name = cpl.GetCampus().GetName() },
                    Building = new() { Name = cpl.GetBuilding().GetName() },
                    Floor = cpl.GetFloor(),
                    Room = new() { Name = cpl.GetRoom().GetName() }
                }).ToList();

            int computerPhysicalLocationCount = await _getComputerPhysicalLocationCountUseCase.ExecuteAsync();
            int totalPages = (int)Math.Ceiling((double)computerPhysicalLocationCount / pageSize);

            return Ok(new ApiResponse<List<ComputerPhysicalLocationReadDto>>
            {
                Data= computerPhysicalLocationsDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage=page,
                        PageSize=pageSize,
                        TotalItems=computerPhysicalLocationCount,
                        TotalPages=totalPages
                    }
                }
            });
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse<ComputerPhysicalLocationReadDto>>> ListByIdAsync(Guid id)
        {
            var computerPhysicalLocation = await _getComputerPhysicalLocationUseCase.ExecuteAsync(id);
            if (computerPhysicalLocation is null)
                return NotFound();

            var computerPhysicalLocationDto = new ComputerPhysicalLocationReadDto
            {
                Campus = new() { Name = computerPhysicalLocation.GetCampus().GetName() },
                Building = new() { Name = computerPhysicalLocation.GetBuilding().GetName() },
                Floor = computerPhysicalLocation.GetFloor(),
                Room = new() { Name = computerPhysicalLocation.GetRoom().GetName() }
            };

            return Ok(new ApiResponse<ComputerPhysicalLocationReadDto>
            {
                Data = computerPhysicalLocationDto,
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
        public async Task<ActionResult> AddAsync([FromBody] ComputerPhysicalLocationCreateDto computerPhysicalLocationCreateDto)
        {
            var computerPhysicalLocation = new ComputerPhysicalLocation(
                computerPhysicalLocationCreateDto.IdCampus,
                computerPhysicalLocationCreateDto.IdBuilding,
                computerPhysicalLocationCreateDto.FloorNumber,
                computerPhysicalLocationCreateDto.IdRoom);

            await _addComputerPhysicalLocationUseCase.ExecuteAsync(computerPhysicalLocation);
            computerPhysicalLocation = await _getComputerPhysicalLocationUseCase.ExecuteAsync(computerPhysicalLocation.GetId());
            var computerPhysicalLocationReadDto = new ComputerPhysicalLocationReadDto
            {
                Campus = new() { Name = computerPhysicalLocation.GetCampus().GetName() },
                Building = new() { Name = computerPhysicalLocation.GetBuilding().GetName() },
                Floor = computerPhysicalLocation.GetFloor(),
                Room = new() { Name = computerPhysicalLocation.GetRoom().GetName() }
            };

            return CreatedAtRoute(
                nameof(ListByIdAsync),
                new
                {
                    id = computerPhysicalLocation.GetId()
                },
                computerPhysicalLocationReadDto);
        }
    }
}
