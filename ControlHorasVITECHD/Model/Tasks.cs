using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlHorasVITECHD.Model
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public int TaskNumber { get; set; }
        [ForeignKey("Proyects")]
        public int IdProyect { get; set; }
        [ForeignKey("Users")]
        public string IdUser { get; set; }
        public string Detail { get; set; }
        public int EstimatedHours { get; set; }
        public ICollection<Hours> Hours { get; set; }
        public virtual ApplicationUser Users { get; set; }
        public virtual Proyects Proyects { get; set; }
    }
    
}
