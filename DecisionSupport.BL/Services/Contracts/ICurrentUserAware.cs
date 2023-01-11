using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.BL.Services.Contracts
{
    public interface ICurrentUserAware
    {
        Task<User?> GetCurrentUser();
    }
}
