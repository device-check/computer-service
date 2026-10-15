using application.UseCases.ComputerTypeUseCases;
using Asp.Versioning;
using interface_adapters.Dtos.ComputerType;
using interface_adapters.Responses;
using Microsoft.AspNetCore.Mvc;

namespace interface_adapters.Controllers.v1
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ComputerTypeController : ControllerBase
    {
        public readonly GetComputerTypeUseCase _getComputerTypeUseCase;
        public readonly GetComputerTypeCountUseCase _getComputerTypeCountUseCase;

        public ComputerTypeController(GetComputerTypeUseCase getComputerTypeUseCase, GetComputerTypeCountUseCase getComputerTypeCountUseCase)
        {
            _getComputerTypeUseCase = getComputerTypeUseCase;
            _getComputerTypeCountUseCase = getComputerTypeCountUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ComputerTypeReadDto>>>> ListAsync(
            [FromQuery] int page=1, 
            [FromQuery] int pageSize=10)
        {
            var computerTypes = await _getComputerTypeUseCase.ExecuteAsync(page, pageSize);
            var computerTypesDto = computerTypes
                .Select(ct => new ComputerTypeReadDto
                {
                    Name = ct.GetName()
                }).ToList();

            int computerTypeCount = await _getComputerTypeCountUseCase.ExecuteAsync();
            int totalPages = (int)Math.Ceiling((double)computerTypeCount / pageSize);

            return Ok(new ApiResponse<List<ComputerTypeReadDto>>
            {
                Data=computerTypesDto,
                MetaData = new()
                {
                    Pagination = new()
                    {
                        CurrentPage=page,
                        PageSize=pageSize,
                        TotalItems=computerTypeCount,
                        TotalPages=totalPages
                    }
                }
            });

        }
    }
}
