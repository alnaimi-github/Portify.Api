using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portify.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string email, string[] roles);
    }
}
