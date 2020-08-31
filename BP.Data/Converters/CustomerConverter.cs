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
    }
}
