using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HSC_Roll { get; set; }
        public string PhoneNo { get; set; }
        public string Type { get; set; }
    }
}
