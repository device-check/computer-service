using application.UseCases.CampusUseCases;
using Asp.Versioning;
using domain.Entities;
using interface_adapters.Dtos.Campus;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;

namespace interface_adapters.Controllers.v1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CampusController : ControllerBase
    {
        private readonly GetCampusCountUseCase _getCampusCountUseCase;
        private readonly GetCampusUseCase _getCampusUseCase;
        private readonly AddCampusUseCase _addCampusUseCase;
        private readonly DeleteCampusUseCase _deleteCampusUseCase;

        public CampusController(GetCampusUseCase getCampusUseCase, AddCampusUseCase addCampusUseCase, DeleteCampusUseCase removeCampusUseCase, GetCampusCountUseCase getCampusCountUseCase)
        {
            _getCampusUseCase = getCampusUseCase;
            _addCampusUseCase = addCampusUseCase;
            _deleteCampusUseCase = removeCampusUseCase;
            _getCampusCountUseCase = getCampusCountUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<CampusReadDto>>>> ListAsync(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            var campus = await _getCampusUseCase.ExecuteAsync(page, pageSize);
            var campusReadDto = campus.Select(c => new CampusReadDto
            {
                Name = c.GetName()
            }).ToList();

            int campusCount = await _getCampusCountUseCase.ExecuteAsync();
            int totalPages = (int)Math.Ceiling((double)campusCount / pageSize);

            return Ok(new ApiResponse<List<CampusReadDto>>
            {
                Data = campusReadDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        PageSize = pageSize,
                        CurrentPage = page,
                        TotalItems = campusCount,
                        TotalPages = totalPages
                    }
                }
            });
        }

        [HttpGet("{id:Guid}", Name = nameof(ListByIdAsync))]
        public async Task<ActionResult<ApiResponse<CampusReadDto>>> ListByIdAsync(Guid id)
        {
            var campus = await _getCampusUseCase.ExecuteAsync(id);
            if (campus is null)
                return NotFound();

            var campusReadDto = new CampusReadDto
            {
                Name = campus.GetName()
            };

            return Ok(new ApiResponse<CampusReadDto>
            {
                Data = campusReadDto,
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
        public async Task<ActionResult> AddAsync([FromBody] CampusCreateDto campusCreateDto)
        {
            Campus campus = new(campusCreateDto.Name);
            await _addCampusUseCase.ExecuteAsync(campus);
            var campusReadDto = new CampusReadDto
            {
                Name = campus.GetName()
            };

            return CreatedAtRoute(
                nameof(ListByIdAsync), 
                new 
                { 
                    id = campus.GetId()
                }, 
                campusReadDto);            
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> RemoveAsync(Guid id)
        {
            Campus? campus = await _getCampusUseCase.ExecuteAsync(id);
            if (campus is null)
                return NotFound();

            await _deleteCampusUseCase.ExecuteAsync(campus);
            return Ok();
        }
    }
}
