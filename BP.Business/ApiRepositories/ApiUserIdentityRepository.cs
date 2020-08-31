using BP.ApiRepositories.Interfaces;
using BP.Converters;
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
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly UserConverter _userConverter;

        public ApiUserIdentityRepository(IUserIdentityRepository userIdentityRepository, IUserRepository userRepository, AuthenticationService authenticationService, UserConverter userConverter)
        {
            _userIdentityRepository = userIdentityRepository;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _userConverter = userConverter;
        }

        public async Task<string> GetAuthTokenAsync(UserIdentity userIdentity)
        {
            if (!_authenticationService.IsValidApiPassword(userIdentity.ApiPassword))
            {
                throw new InvalidApiPasswordException();
            }
            User userDB = _userConverter.Convert(await _userIdentityRepository.GetUserIdentityAsync(userIdentity.Username));
            userDB.UserID = await _userRepository.GetAssociatedUserIDAsync(userDB.UserIdentityID, userDB.Role);
            if (_authenticationService.IsValidPassword(userIdentity.Password, userDB.PasswordSalt, userDB.PasswordHash))
            {
                return _authenticationService.GetToken(userDB);
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }

    }
}
