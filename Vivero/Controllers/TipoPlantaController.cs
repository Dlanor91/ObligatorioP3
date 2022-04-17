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
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                IEnumerable<TipoPlanta> tp = ManejadorTipoPlantas.MostrarTodosTiposPlantas();
                return View(tp);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Busqueda()
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
        public ActionResult Busqueda(string nombreTP)
        {
            try
            {
                if (nombreTP == null)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    TipoPlanta tp = ManejadorTipoPlantas.buscarPlantaNombre(nombreTP);
                    if (tp == null)
                    {
                        throw new Exception("No se encontraron coincidencias con " + nombreTP + " .");
                    }
                    else
                    {
                        return View(tp);
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
           
        }

        // GET: TipoPlantaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoPlantaController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                TipoPlanta tpNew = new TipoPlanta();
                return View(tpNew);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: TipoPlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPlanta tpNew)
        {
            try
            {
                bool validarNewTp = tpNew.Validar();                

                if (validarNewTp)
                {
                    bool errorNombre = ManejadorTipoPlantas.ValidarFormatoNombre(tpNew.nombre);
                    if (!errorNombre)
                    {
                        bool existeNombre = ManejadorTipoPlantas.ValidarNombreUnico(tpNew.nombre);
                        if (!existeNombre)                        
                        {
                            if (tpNew.descripcionTipo.Length >=10 && tpNew.descripcionTipo.Length <=200)
                            {
                                bool altaTP = ManejadorTipoPlantas.AgregarTipoPlanta(tpNew);
                                if (altaTP)
                                {
                                    return RedirectToAction(nameof(Index));
                                }
                                else
                                {
                                    throw new Exception("No fue posible el alta de un nuevo Tipo de Planta.");                                    
                                }
                            }
                            else
                            {
                                throw new Exception("El campo descripción debe estar entre 10 y 200 caracteres.");                                
                            }
                        }
                        else
                        {
                            throw new Exception("El nombre del Tipo de Planta ya existe en la base de datos, ingrese otro.");                           
                        }
                    }
                    else {
                        throw new Exception("El nombre del Tipo de Planta tiene espacios embebidos o tiene números, verifíquelo.");                        
                    }                    
                }
                else {
                    throw new Exception("Complete todos los campos.");                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: TipoPlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                TipoPlanta tpEdit = ManejadorTipoPlantas.buscarUnaPlanta(id);
                return View(tpEdit);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
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
