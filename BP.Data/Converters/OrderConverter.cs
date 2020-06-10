using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    internal class OrderConverter
    {
        public Models.Order Convert(Entities.Order order)
        {
            return new Models.Order
            {
                ClientId = order.ClientId,
                EndLocationLat = order.EndLocationLat,
                EndLocationLng = order.EndLocationLng,
                EndTimeEstimate = order.EndTimeEstimate,
                OrderId = order.OrderId,
                StartLocationLat = order.StartLocationLat,
                StartLocationLng = order.StartLocationLng,
                StartTime = order.StartTime,
                VehicleId = order.VehicleId
            };
        }

        public IEnumerable<Models.Order> Convert(IEnumerable<Entities.Order> orders)
        {
            return orders.Select(x => Convert(x));
        }
    }
}
