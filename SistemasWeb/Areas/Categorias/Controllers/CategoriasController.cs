using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Controllers;
using SistemasWeb.Data;
using SistemasWeb.Library;
using SistemasWeb.Models;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    [Route("Categorias/[controller]/[action]")]
    [Authorize]
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

        public IActionResult Index(int id, string search, int records)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _lCategoria.GetByFilterCategorias(search);
                if(data.Count > 0)
                {
                    //Con esto 'Request.Scheme' obtengo el https. Con esto 'Request.Host.Value' obtengo el host
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<TCategoria>().Paginador(data, id, records, "Categorias", "Categorias", "Index", url);
                }
                else
                {
                    objects[0] = "";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<TCategoria>();
                }
                models = new DataPaginador<TCategoria>
                {
                    List = (List<TCategoria>)objects[2],
                    PagiInfo = (string)objects[0],
                    PagiNavegation = (string)objects[1],
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
        public string SaveCategorias(DataPaginador<TCategoria> model)
        {
            if(model.Entity.Name != null && model.Entity.Code != null)
            {
                var result = _lCategoria.RegistrarCategoria(model.Entity);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return "Llene los campos requeridos";
            }
        }
    }
}
