using System;
using System.ComponentModel.DataAnnotations;

namespace dev.eduardroid.services.ViewModel
{
    public class NavigationRightViewModel
    {
        [Required]
        public Int32 NavigationRightId { get; set; }
        [Required]
        public String NavigationRightWebPage { get; set; }
    }
}