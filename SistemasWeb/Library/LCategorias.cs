using Microsoft.AspNetCore.Identity;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Library
{
    public class LCategorias
    {
        private ApplicationDbContext _context;

        public LCategorias(ApplicationDbContext context)
        {
            _context = context;
        }

        public IdentityError RegistrarCategoria(TCategoria categoria)
        {
            IdentityError identityError;
            try
            {
                _context.Add(categoria);
                _context.SaveChanges();
                identityError = new IdentityError { Code = "Done" };
            }
            catch(Exception ex)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = ex.Message
                };
            }
            return identityError;
        }
        public List<TCategoria> GetByFilterCategorias(string text)
        {
            List<TCategoria> listCategorias;
            if(text == null)
            {
                listCategorias = _context.TCategoria.ToList();
            }
            else
            {
                listCategorias = _context.TCategoria.Where(c => c.Name.StartsWith(text)).ToList();
            }
            return listCategorias;
        }
    }
}
