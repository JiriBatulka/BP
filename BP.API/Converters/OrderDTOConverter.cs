using BP.DTOs;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Converters
{
    public class OrderDTOConverter
    {
        public Order Convert(OrderDTO.AddOrderDTO addOrderDTO)
        {
            return new Order
            {
                CustomerID = addOrderDTO.CustomerID,
                EndLocationLat = addOrderDTO.EndLocationLat,
                EndLocationLng = addOrderDTO.EndLocationLng,
                StartLocationLat = addOrderDTO.StartLocationLat,
                StartLocationLng = addOrderDTO.StartLocationLng,
                StartTime = addOrderDTO.StartTime
            };
        }
    }
}
