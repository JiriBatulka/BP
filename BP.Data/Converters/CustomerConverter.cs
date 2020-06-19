using System;
using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    public class CustomerConverter
    {
        public Entities.Customer Convert(Models.Customer customer)
        {
            return new Entities.Customer
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                CurrentLat = customer.CurrentLat,
                CurrentLng = customer.CurrentLng
            };
        }
    }
}
