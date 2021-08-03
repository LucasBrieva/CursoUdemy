using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Areas.Categorias.Models
{
    public class TCategoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo obligatorio")]
        [MaxLength(5, ErrorMessage = "No puede ser mayor a 5 caracteres")]
        [Display(Name="Código")]
        public string Code { get; set; }

        [Required(ErrorMessage ="*Campo obligatorio")]
        [MaxLength(50, ErrorMessage ="No puede ser mayor a 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage ="No puede ser mayor a 250 caracteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        public bool State { get; set; } = true;

        //public ICollection<TProductos> Productos { get; set; }
    }
}
