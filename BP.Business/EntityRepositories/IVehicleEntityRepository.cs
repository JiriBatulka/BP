using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IVehicleEntityRepository
    {
        public Task AddVehicleAsync(Vehicle vehicle);
        public Task MoveVehicleAsync(Vehicle vehicle);
    }
}
