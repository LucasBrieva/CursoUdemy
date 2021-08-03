using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Controllers;
using SistemasWeb.Data;
using SistemasWeb.Library;
using SistemasWeb.Models;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    [Route("Categorias/[controller]/[action]")]
    public class CategoriasController : Controller
    {
        private TCategoria _categoria;
        private LCategorias _lCategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;

        public CategoriasController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lCategoria = new LCategorias(context);
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPaginador<TCategoria>
                {
                    Entity = new TCategoria(),
                };
                return View(models);

            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
        }
        [HttpPost]
        public String SaveCategorias(DataPaginador<TCategoria> model)
        {
            if(model.Entity.Name != null && model.Entity.Code != null)
            {
                return "Hola";
            }
            else
            {
                return "Llene los campos requeridos";
            }
        }
    }
}
