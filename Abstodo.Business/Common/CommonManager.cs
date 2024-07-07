using Abstodo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Abstodo.Business.Common
{
    public class CommonManager:ICommonService
    {
        public async Task<int> GetUserIDFromClaims(ClaimsIdentity userIdentity)
        {
            return Convert.ToInt32(userIdentity.Claims.FirstOrDefault(t => t.Type == "ID").Value);
        }
    }
}
