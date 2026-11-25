using application.Exceptions;
using application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.UseCases.ComputerPhysicalLocationUseCases
{
    public class UpdateComputerPhysicalLocationUseCase
    {
        private readonly IComputerPhysicalLocationRepository _computerPhysicalLocationRepository;

        public UpdateComputerPhysicalLocationUseCase(IComputerPhysicalLocationRepository computerPhysicalLocationRepository)
        {
            _computerPhysicalLocationRepository = computerPhysicalLocationRepository;
        }

        public async Task ExecuteAsync(
            Guid id, 
            Guid? id_campus, 
            Guid? id_building, 
            int? floorNumber, 
            Guid? id_room)
        {
            // pre-contract

            if (id == Guid.Empty)
                throw new ApplicationLayerException(
                    "Computer Physical Location ID cannot be empty.");

            if (
                id_campus is null &&
                id_building is null &&
                floorNumber is null &&
                id_room is null
            )
                throw new ApplicationLayerException(
                    "At least one attribute must be provided for updating the physical location.");


            await _computerPhysicalLocationRepository.UpdateAsync(id, id_campus, id_building, floorNumber, id_room);
        }

    }
}
