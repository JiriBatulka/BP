using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static BP.DTOs.CustomerDTO;

namespace BP.Converters
{
    public class CustomerConverter
    {
        public Customer Convert(AddCustomerDTO addCustomerDTO)
        {
            return new Customer
            {
                FirstName = addCustomerDTO.FirstName,
                Surname = addCustomerDTO.Surname,
            };
        }

        public Customer Convert(MoveCustomerDTO moveCustomerDTO)
        {
            return new Customer
            {
                CustomerID = moveCustomerDTO.CustomerID,
                CurrentLat = moveCustomerDTO.TargetLat,
                CurrentLng = moveCustomerDTO.TargetLng,
            };
        }
    }
}
