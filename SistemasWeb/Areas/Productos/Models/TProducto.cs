using SistemasWeb.Areas.Categorias.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Areas.Productos.Models
{
    public class TProducto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "*Campo obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "*Campo obligatorio")]
        public string Code { get; set; }

        [Display(Name = "Vencimiento")]
        public DateTime? DueDate { get; set; }

        [Display(Name= "Costo")]
        [Required(ErrorMessage ="*Campo obligatorio")]
        public decimal CostPrice { get; set; }

        [Display(Name = "Stock")]
        public int? Stock { get; set; }

        [Display(Name="Descripción")]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        public bool State { get; set; }
        public byte[] Image { get; set; }
        public int CategoriaId { get; set; }
        public TCategoria Categoria { get; set; }

    }
}
