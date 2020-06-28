using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.eduardroid.services.Data.Entities
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Nickname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public ICollection<NavigationRight> Rights { get; set; }
    }
}
