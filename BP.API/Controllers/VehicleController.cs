using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BP.DTOs;

namespace BP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IApiVehicleRepository vehicleRepository;
        private readonly VehicleDTOConverter vehicleDTOConverter;

        public VehicleController(IApiVehicleRepository vehicleRepository, VehicleDTOConverter vehicleDTOConverter)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleDTOConverter = vehicleDTOConverter;
        }

        [HttpGet("add")]
        public async Task<Guid> AddVehicleAsync([FromBody] VehicleDTO.AddVehicleDTO value)
        {
            return await vehicleRepository.AddVehicleAsync(vehicleDTOConverter.Convert(value));
        }

        [HttpGet("move")]
        public async Task MoveVehicleAsync([FromBody] VehicleDTO.MoveVehicleDTO value)
        {
            await vehicleRepository.MoveVehicleAsync(vehicleDTOConverter.Convert(value));
        }
    }
}
