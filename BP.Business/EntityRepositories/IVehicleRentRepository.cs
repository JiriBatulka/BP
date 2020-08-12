using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IVehicleRentRepository
    {
        public Task AddVehicleRentAsync(VehicleRent vehicleRent);
    }
}
