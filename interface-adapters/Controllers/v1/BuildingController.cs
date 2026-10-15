using application.UseCases.BuildingUseCases;
using Asp.Versioning;
using domain.Entities;
using interface_adapters.Dtos.Building;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;

namespace interface_adapters.Controllers.v1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly GetBuildingCountUseCase _getBuildingCountUseCase;
        private readonly AddBuildingUseCase _addBuildingUseCase;
        private readonly GetBuildingUseCase _getBuildingUseCase;
        private readonly DeleteBuildingUseCase _deleteBuildingUseCase;

        public BuildingController(AddBuildingUseCase addBuildingUseCase, GetBuildingUseCase getBuildingUseCase, DeleteBuildingUseCase deleteBuildingUseCase, GetBuildingCountUseCase getBuildingCountUseCase)
        {
            _addBuildingUseCase = addBuildingUseCase;
            _getBuildingUseCase = getBuildingUseCase;
            _deleteBuildingUseCase = deleteBuildingUseCase;
            _getBuildingCountUseCase = getBuildingCountUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Building>>>> ListAsync(
            [FromQuery] int page=1,
            [FromQuery] int pageSize = 10)
        {
            var buildings = await _getBuildingUseCase.ExecuteAsync(page, pageSize);
            var buildingsDto = buildings.Select(b => new BuildingReadDto
            {
                Name = b.GetName()
            });

            var buildingsCount = await _getBuildingCountUseCase.ExecuteAsync();
            var totalPages = (int)Math.Ceiling((double)buildingsCount / pageSize);

            return Ok(new ApiResponse<IEnumerable<BuildingReadDto>>
            {
                Data = buildingsDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalItems = buildingsCount,
                        TotalPages = totalPages
                    }
                }
            });
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse<Building>>> ListByIdAsync(Guid id)
        {
            var building = await _getBuildingUseCase.ExecuteAsync(id);
            if (building is null)
                return NotFound();

            var buildingDto = new BuildingReadDto
            {
                Name = building.GetName()
            };

            return Ok(new ApiResponse<BuildingReadDto>
            {
                Data = buildingDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        PageSize = 1,
                        CurrentPage = 1,
                        TotalItems = 1,
                        TotalPages = 1
                    }
                }
            });
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] BuildingCreateDto buildingCreateDto)
        {
            var building = new Building(buildingCreateDto.Name);
            await _addBuildingUseCase.ExecuteAsync(building);
            var buildingReadDto = new BuildingReadDto
            {
                Name = building.GetName()
            };


            return CreatedAtRoute(
                nameof(ListByIdAsync),
                new
                {
                    id = building.GetId()
                },
                buildingReadDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> RemoveAsync(Guid id)
        {
            var building = await _getBuildingUseCase.ExecuteAsync(id);
            if (building is null)
                return NotFound();

            await _deleteBuildingUseCase.ExecuteAsync(building);

            return NoContent();
        }
    }
}
