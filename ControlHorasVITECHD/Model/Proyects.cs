using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlHorasVITECHD.Model
{
    public class Proyects
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        public string Name { get; set; }
        public int Hours { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InitialDate { get; set; }
        [ForeignKey("Clients")]
        public int IdClient { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public virtual Clients Clients { get; set; }

    }
}
