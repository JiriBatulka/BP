using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IVehicleRentEntityRepository
    {
        public Task AddVehicleRentAsync(VehicleRent vehicleRent);
    }
}
