using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiVehicleRentRepository
    {
        public Task AddVehicleRentAsync(VehicleRent vehicleRent);
    }
}
