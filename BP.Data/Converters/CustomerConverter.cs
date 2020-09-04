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
                CustomerID = customer.UserID,
                FirstName = customer.FirstName,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                CurrentLat = customer.CurrentLat,
                CurrentLng = customer.CurrentLng,
                IsActive = customer.IsActive,
                UserIdentityID = customer.UserIdentityID,
                Email = customer.Email
            };
        }

        public Models.Customer Convert(Entities.Customer customer)
        {
            return new Models.Customer
            {
                UserID = customer.CustomerID,
                FirstName = customer.FirstName,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                CurrentLat = customer.CurrentLat,
                CurrentLng = customer.CurrentLng,
                IsActive = customer.IsActive,
                UserIdentityID = customer.UserIdentityID,
                Email = customer.Email
            };
        }

        internal IEnumerable<Models.Customer> Convert(IEnumerable<Entities.Customer> customers)
        {
            return customers.Select(x => Convert(x)).ToList();
        }
    }
}
