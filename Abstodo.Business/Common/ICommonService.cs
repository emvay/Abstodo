using System.Security.Claims;

namespace Abstodo.Business.Common
{
    public interface ICommonService
    {
        Task<int> GetUserIDFromClaims(ClaimsIdentity userIdentity);
    }
}
