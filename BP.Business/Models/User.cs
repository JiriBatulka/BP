namespace BP.Models
{
    public class User : UserIdentity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
    }
}
