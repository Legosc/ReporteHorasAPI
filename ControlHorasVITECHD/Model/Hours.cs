using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlHorasVITECHD.Model
{
    public class Hours
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int IdTask { get; set; }
        public int HoursTime { get; set; }
        public TypeStatus Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        [ForeignKey("Users")]
        public string IdUser { get; set; }
        public virtual ApplicationUser Users { get; set; }
        public virtual Tasks Tasks { get; set; }
    }

    public enum TypeStatus
    {
        Assigned,
        Progress,
        Wait,
        Test,
        Completed
    }
}
