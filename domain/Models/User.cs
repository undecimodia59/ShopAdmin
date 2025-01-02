using Microsoft.AspNetCore.Identity;

namespace admin_panel.Data.Models
{
    public class User : IdentityUser
    {
        public string Username { get; set; }
    }
}
