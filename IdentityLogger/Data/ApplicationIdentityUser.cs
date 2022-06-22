using Microsoft.AspNetCore.Identity;

namespace IdentityLogger.Data
{
    public class ApplicationIdentityUser:IdentityUser
    {

        public int Age { get; set; }


    }
}
