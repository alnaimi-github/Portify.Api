using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portify.Infrastructure.Configuration.Settings
{
    public class JwtSettings
    {
        required public string Key { get; set; }
        required public string Issuer { get; set; }
        required public string Audience { get; set; }
        required public int ExpiryMinutes { get; set; }
    }
}
