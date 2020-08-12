using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiUserIdentityRepository : IApiUserIdentityRepository
    {
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly PasswordService _passwordService;

        public ApiUserIdentityRepository(IUserIdentityRepository userIdentityRepository, PasswordService passwordService)
        {
            _userIdentityRepository = userIdentityRepository;
            _passwordService = passwordService;
        }

        public async Task CheckUserIdentityAsync(UserIdentity userIdentity)
        {
            userIdentity.DecryptedPassword = _passwordService.Decrypt(userIdentity.DecryptedPassword);
            var hashAndSalt = await _userIdentityRepository.GetHashSaltAsync(userIdentity.Username);
            if (_passwordService.PasswordCheck(userIdentity.DecryptedPassword, hashAndSalt.Salt, hashAndSalt.Hash))
            {
                return;
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }

    }
}
