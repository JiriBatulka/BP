using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    public class OrderConverter
    {
        public Entities.Order Convert(Models.Order order)
        {
            return new Entities.Order
            {
                CustomerID = order.CustomerID,
                EndLocationLat = order.EndLocationLat,
                EndLocationLng = order.EndLocationLng,
                EndTimeEstimate = order.EndTimeEstimate,
                OrderID = order.OrderID,
                StartLocationLat = order.StartLocationLat,
                StartLocationLng = order.StartLocationLng,
                StartTime = order.StartTime,
                VehicleID = order.VehicleID
            };
        }
    }
}
