namespace BP.Simulation.DTOs
{
    public class CustomerDTO
    {
        public class AddCustomerDTO
        {
            public string Surname { get; set; }
            public string FirstName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string EncryptedPassword { get; set; }
        }

        public class GetCustomersDTO
        {
            public string FirstName { get; set; }

            public string Surname { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public double? CurrentLat { get; set; }

            public double? CurrentLng { get; set; }

            public bool? IsActive { get; set; }
        }
    }
}
