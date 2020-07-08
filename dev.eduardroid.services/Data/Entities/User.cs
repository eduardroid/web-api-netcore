//using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace dev.eduardroid.services.Data.Entities
{
    public class User //: IdentityUser
    {
        public Int32 Id { get; set; }
        public String Nickname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public ICollection<NavigationRight> Rights { get; set; }
    }
}
