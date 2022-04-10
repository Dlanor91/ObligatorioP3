using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDeAplicacion;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;

namespace Vivero.Controllers
{
    public class TipoPlantaController : Controller
    {

        public IManejadorTipoPlantas ManejadorTipoPlantas { get; set; }

        public TipoPlantaController(IManejadorTipoPlantas manejadorTipoPlantas)
        {
            ManejadorTipoPlantas=manejadorTipoPlantas;
        }


        // GET: TipoPlantaController, en el index listamos todos los tipos de planta disponible
        public ActionResult Index()
        {
            IEnumerable<TipoPlanta> tp = ManejadorTipoPlantas.MostrarTodosTiposPlantas();
            return View(tp);
        }

        // GET: TipoPlantaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoPlantaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoPlantaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPlantaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoPlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
