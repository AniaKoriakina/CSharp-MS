using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracted.Connections
{
    public class CheckUser : ICheckUser
    {

        public Task<bool> CheckUserValidAsync(Guid userId)
        {
            return Task.FromResult(true);
        }
    }
}
