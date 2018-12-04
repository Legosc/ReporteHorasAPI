using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlHorasVITECHD.Model
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="El Nombre es Requerido")]
        [MaxLength(50,ErrorMessage ="El nombre no puede ser mayor a 50 caracteres")]
        public string Name { get; set; }
        public TipPer TypePer { get; set; }
        [Required(ErrorMessage = "La identificacion es Requerida")]
        public long NID { get; set; }
        public ICollection<Proyects> Proyects { get; set; }

    }
    public enum TipPer
    {
        [Display(Name = "Física")]
        Fisica,

        [Display(Name = "Jurídica")]
        Juridica
    }
}
