using System.ComponentModel.DataAnnotations;

namespace BP.DTOs
{
    public class UserIdentityDTO
    {
        public class GetAuthTokenDTO
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string EncryptedPassword { get; set; }
        }
    }
}
