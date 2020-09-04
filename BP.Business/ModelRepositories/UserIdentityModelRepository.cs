using BP.Converters;
using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class UserIdentityModelRepository
    {
        private readonly EntityRepositories.IUserIdentityEntityRepository _userIdentityRepository;
        private readonly IUserEntityRepository _userRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly UserConverter _userConverter;

        public UserIdentityModelRepository(EntityRepositories.IUserIdentityEntityRepository userIdentityRepository, IUserEntityRepository userRepository, AuthenticationService authenticationService, UserConverter userConverter)
        {
            _userIdentityRepository = userIdentityRepository;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _userConverter = userConverter;
        }

        public async Task<string> GetAuthTokenAsync(UserIdentity userIdentity)
        {
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
