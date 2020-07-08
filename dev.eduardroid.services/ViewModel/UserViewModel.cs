using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dev.eduardroid.services.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(4)]
        public String UserNickname { get; set; }
        [Required]
        [EmailAddress]
        public String UserEmail { get; set; }
        [Required]
        [MinLength(8)]
        public String UserPassword { get; set; }
        public ICollection<NavigationRightViewModel> UserRights { get; set; }

    }
}
