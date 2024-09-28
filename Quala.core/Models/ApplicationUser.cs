using Microsoft.AspNetCore.Identity;

namespace Quala.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

       
    }
}
