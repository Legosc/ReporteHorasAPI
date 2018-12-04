using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ControlHorasVITECHD.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Hours> Hours { get; set; }

    }
}
