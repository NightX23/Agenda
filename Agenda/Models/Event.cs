using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Evento")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Dirección debe tener entre 5 y 30 caracteres")]
        [Display(Name = "Lugar")]
        public string Location { get; set; }
    }
}
