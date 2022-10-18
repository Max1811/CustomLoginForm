using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using System.Security.Claims;

namespace LoginForm.API.Support
{
    public class CurrentUserAware : ICurrentUserAware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserAware(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<User?> GetCurrentUser()
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;

            if (user != null)
            {
                string? userLogin = user.FindFirst(ClaimTypes.Name)?.Value;

                if (userLogin != null)
                {
                    return await _userRepository.GetByLogin(userLogin);
                }
            }

            return null;
        }
    }
}
