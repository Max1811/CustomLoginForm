using LoginForm.DataAccess.Entities;

namespace LoginForm.BL.Services.Contracts
{
    public interface ICurrentUserAware
    {
        Task<User?> GetCurrentUser();
    }
}
