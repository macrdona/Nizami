using Microsoft.AspNetCore.Identity;
using System;

namespace Nizami.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        //user id is 0 for regular users, 1 for admins
        public int UserId { get; set; }
    }
}
