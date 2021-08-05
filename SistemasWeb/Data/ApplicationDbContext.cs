using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Areas.Productos.Models;

namespace SistemasWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TCategoria> TCategoria { get; set; }
        public DbSet<TProducto> TProducto { get; set; }
    }
}
