using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiVehicleRepository
    {
        public Task AddVehicleAsync(Vehicle vehicle);
        public Task MoveVehicleAsync(Vehicle vehicle);
    }
}
