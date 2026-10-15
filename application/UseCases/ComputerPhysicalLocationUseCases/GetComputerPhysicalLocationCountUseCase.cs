using application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.UseCases.ComputerPhysicalLocationUseCases
{
    public class GetComputerPhysicalLocationCountUseCase
    {
        private readonly IComputerPhysicalLocationRepository _computerPhysicalLocationRepository;

        public GetComputerPhysicalLocationCountUseCase(IComputerPhysicalLocationRepository computerPhysicalLocationRepository)
        {
            _computerPhysicalLocationRepository = computerPhysicalLocationRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _computerPhysicalLocationRepository.CountAsync();
        }
    }
}
