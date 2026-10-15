using application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.UseCases.ComputerTypeUseCases
{
    public class GetComputerTypeCountUseCase
    {
        private readonly IComputerTypeRepository _computerTypeRepository;

        public GetComputerTypeCountUseCase(IComputerTypeRepository computerTypeRepository)
        {
            _computerTypeRepository = computerTypeRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _computerTypeRepository.CountAsync();
        }
    }
}
