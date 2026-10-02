using application.UseCases;
using Asp.Versioning;
using domain.Entities;
using interface_adapters.Dtos.Computer;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.NetworkInformation;

namespace interface_adapters.Controllers.v1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly GetComputerUseCase _getComputerUseCase;
        private readonly AddComputerUseCase _addComputerUseCase;
        private readonly DeleteComputerUseCase _deleteComputerUseCase;

        public ComputerController(GetComputerUseCase getComputerUseCase, AddComputerUseCase addComputerUseCase, DeleteComputerUseCase deleteComputerUseCase)
        {
            _getComputerUseCase = getComputerUseCase;
            _addComputerUseCase = addComputerUseCase;
            _deleteComputerUseCase = deleteComputerUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ComputerReadDto>>>> ListAllAsync(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var computers = await _getComputerUseCase.ExecuteAsync(page, pageSize);
            var computersReadDto = computers.Select(c => new ComputerReadDto
            {
                ComputerIpv4Address = c.GetIpv4Address().ToString(),
                ComputerMacAddress = c.GetMacAddress().ToString(),
                ComputerPowerStatus = c.GetPowerStatus().GetStatus(),
                ComputerType = c.GetComputerType().GetName(),
                ComputerPhysicalLocation = new()
                {
                    Campus = new() { Name=c.GetComputerPhysicalLocation().GetCampus().GetName() },
                    Building = new() { Name=c.GetComputerPhysicalLocation().GetBuilding().GetName()},
                    Floor = c.GetComputerPhysicalLocation().GetFloor(),
                    Room = new() { Name=c.GetComputerPhysicalLocation().GetRoom().GetName()}
                }
            });

            var computersCount = computersReadDto.Count();

            return Ok(new ApiResponse<IEnumerable<ComputerReadDto>>()
            {
                Data = computersReadDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalItems = computersCount,
                        TotalPages = (computersCount/pageSize)
                    }
                }               
            });
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse<ComputerReadDto>>> ListByIdAsync(Guid id)
        {
            var computer = await _getComputerUseCase.ExecuteAsync(id);
            var computerReadDto = computer is null ? null : new ComputerReadDto
            {
                ComputerIpv4Address = computer.GetIpv4Address().ToString(),
                ComputerMacAddress = computer.GetMacAddress().ToString(),
                ComputerType = computer.GetComputerType().GetName(),
                ComputerPowerStatus = computer.GetPowerStatus().GetStatus(),
                ComputerPhysicalLocation = new()
                {
                    Campus = new() { Name = computer.GetComputerPhysicalLocation().GetCampus().GetName() },
                    Building = new() { Name = computer.GetComputerPhysicalLocation().GetBuilding().GetName() },
                    Floor = computer.GetComputerPhysicalLocation().GetFloor(),
                    Room = new() { Name = computer.GetComputerPhysicalLocation().GetRoom().GetName() }
                }
            };

            return Ok(new ApiResponse<ComputerReadDto>()
            {
                Data = computerReadDto,
                MetaData = new() 
                {
                    Pagination = new()
                    {
                        CurrentPage = 1,
                        TotalItems = computer is null ? 0 : 1,
                        PageSize = 1,
                        TotalPages = 1
                    }                    
                }
            });
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ComputerCreateDto computerCreateDto)
        {
            var computer = new Computer(
                computerCreateDto.IdComputerType,
                computerCreateDto.IdSupport,
                computerCreateDto.IdComputerPhysicalLocation,
                PhysicalAddress.Parse(computerCreateDto.ComputerMacAddress),
                IPAddress.Parse(computerCreateDto.ComputerIpv4Address)
                );

            await _addComputerUseCase.ExecuteAsync(computer);
            var computerReadDto = await ListByIdAsync(computer.GetId());

            return CreatedAtAction(nameof(ListByIdAsync), new { id = computer.GetId() }, computerReadDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromQuery] Guid id_computer)
        {
            await _deleteComputerUseCase.ExecuteAsync(id_computer);

            return NoContent();
        }

    }
}
