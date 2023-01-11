using DecisionSupport.BL.Algorithms;
using DecisionSupport.BL.Parsing;
using DecisionSupport.BL.Parsing.Models;
using DecisionSupport.BL.Services.Contracts;
using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DecisionSupport.BL.Services
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
