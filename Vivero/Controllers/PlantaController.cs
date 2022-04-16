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
    public class PlantaController : Controller
    {
        
        public IManejadorPlanta ManejadorPlanta { get; set; }
        
        public PlantaController(IManejadorPlanta manejadorPlanta)
            {
                ManejadorPlanta = manejadorPlanta;
            }
        
        
        // GET: PlantaController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                IEnumerable<Planta> pl = ManejadorPlanta.MostrarTodasPlantas();
                return View(pl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Busquedas()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //Busqueda de Plantas por Nombre de Planta
        public ActionResult BusqPorNombre()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqPorNombre(string nombreBusqPlanta)
        {
            
            try
            {
                if (nombreBusqPlanta == null)
                {
                    throw new Exception("Complete el campo de búsqueda.");                    
                }
                else
                {
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.BusquedaNombre(nombreBusqPlanta);
                    if (plEncontradas.Count() == 0)
                    {
                        throw new Exception("No se encontraron coincidencias con " + nombreBusqPlanta + " .");
                    }
                    else
                    {
                        return View(plEncontradas);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        //busqueda por tipo de ambiente
        public ActionResult BusqTipoAmbiente()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        
        }
        
        [HttpPost]
        public ActionResult BusqTipoAmbiente(int busqTipoAmbiente)
        {
            try
            {
                if (busqTipoAmbiente == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasTipoAmbiente(busqTipoAmbiente);
                    if (plEncontradas.Count() == 0)
                    {
                        throw new Exception("No se encontraron plantas con ese criterio de búsqueda.");
                    }
                    else
                    {
                        return View(plEncontradas);
                    }                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //Busqueda de Plantas por Altura menor que ciertas Plantas
        public ActionResult BusqMenorAltura()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqMenorAltura(int busqAlturaMinima)
        {
            try
            {
                 if (busqAlturaMinima == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMenoresAlt(busqAlturaMinima);
                    if (plEncontradas.Count() == 0)
                    {
                       throw new Exception("No se encontraron plantas menor que " + busqAlturaMinima + " cm.");
                    }
                    else
                    {
                       return View(plEncontradas);
                    }                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        
        //Busqueda de Plantas mayor Altura
        public ActionResult BusqMayorAltura()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqMayorAltura(int busqAlturaMaxima)
        {
            try
            {
                if (busqAlturaMaxima == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMayoresAlt(busqAlturaMaxima);
                    if (plEncontradas.Count() == 0)
                    {
                        throw new Exception("No se encontraron plantas mayor que " + busqAlturaMaxima + " cm.");
                    }
                    else
                    {
                        return View(plEncontradas);
                    }                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PlantaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlantaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantaController/Create
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

        // GET: PlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlantaController/Edit/5
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

        // GET: PlantaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlantaController/Delete/5
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
