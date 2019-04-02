using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public  string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage ="Dirección debe tener entre 10 y 30 caracteres")]
        [Display(Name = "Dirección")]
        public  string Address { get; set; }
    }
}
