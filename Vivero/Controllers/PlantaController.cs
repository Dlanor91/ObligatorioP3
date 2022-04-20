using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDeAplicacion;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Hosting;
using Vivero.Models;
using System.IO;

namespace Vivero.Controllers
{
    public class PlantaController : Controller
    {
        
        public IManejadorPlanta ManejadorPlanta { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public PlantaController(IManejadorPlanta manejadorPlanta, IWebHostEnvironment webHostEnvironment)
        {
            ManejadorPlanta=manejadorPlanta;
            WebHostEnvironment=webHostEnvironment;
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
                    nombreBusqPlanta = nombreBusqPlanta.Trim();
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

        //Busqueda de Plantas por Tipo de Planta
        public ActionResult BusqTipoPlanta()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                MostrarPlantaAtributos();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqTipoPlanta(int busqTipoPlanta)
        {

            try
            {
                if (busqTipoPlanta == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasTipoPlanta(busqTipoPlanta);
                    if (plEncontradas.Count() == 0)
                    {
                        
                        throw new Exception("No se encontraron coincidencias con ese criterio de búsqueda.");
                    }
                    else
                    {                        
                        MostrarPlantaAtributos();
                        return View(plEncontradas);
                    }

                }
            }
            catch (Exception ex)
            {                
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;
                return View();
            }
        }                    

        //busqueda por tipo de ambiente
        public ActionResult BusqTipoAmbiente()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                MostrarPlantaAtributos();
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
                        MostrarPlantaAtributos();
                        return View(plEncontradas);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MostrarPlantaAtributos();
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
                    throw new Exception("Complete el campo de búsqueda o introduzca una altura mayor que 0.");
                }
                else
                {
                    if (busqAlturaMinima<0) {
                        throw new Exception("Introduzca una altura mayor que 0.");
                    } 
                    else {
                        IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMenoresAlt(busqAlturaMinima);
                        if (plEncontradas.Count() == 0)
                        {
                            throw new Exception("No se encontraron plantas menores que " + busqAlturaMinima + " cm.");
                        }
                        else
                        {
                            return View(plEncontradas);
                        }
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
                    throw new Exception("Complete el campo de búsqueda o introduzca una altura mayor que 0.");
                }
                else
                {
                    if (busqAlturaMaxima<0)
                    {
                        throw new Exception("Introduzca una altura mayor que 0.");
                    }
                    else
                    {
                        IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMayoresAlt(busqAlturaMaxima);
                        if (plEncontradas.Count() == 0)
                        {
                            throw new Exception("No se encontraron plantas mayores que " + busqAlturaMaxima + " cm.");
                        }
                        else
                        {
                            return View(plEncontradas);
                        }
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
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                MostrarPlantaAtributos();
                return View() ;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelPlanta VMPlanta, int minimaDesc, int maximaDesc)
        {
            try
            {                
                bool validarNewTp = VMPlanta.Planta.Validar();

                if (validarNewTp && VMPlanta.idIluminacion != 0 && VMPlanta.idTipoAmbiente != 0 && VMPlanta.idTipoPlanta != 0 && VMPlanta.Foto!=null)  
                {
                    if (VMPlanta.Planta.alturaMax <= 0) {
                        throw new Exception("La altura máxima no puede ser menor que 0cm.");
                    } 
                    else {
                        bool errorNombre = VMPlanta.Planta.ValidarFormatoNombre(VMPlanta.Planta.nombreCientifico);
                        if (!errorNombre)
                        {
                            VMPlanta.Planta.nombreCientifico = VMPlanta.Planta.nombreCientifico.Trim();
                            bool existeNombre = ManejadorPlanta.verificarNombreC(VMPlanta.Planta.nombreCientifico);
                            if (!existeNombre)
                            {
                                VMPlanta.Planta.descripcionPlanta = VMPlanta.Planta.descripcionPlanta.Trim();
                                VMPlanta.Planta.nombresVulgares = VMPlanta.Planta.nombresVulgares.Trim();
                                bool descripcionValida = VMPlanta.Planta.ValidarDescripcion(VMPlanta.Planta.descripcionPlanta, minimaDesc, maximaDesc);
                                if (descripcionValida)
                                {
                                    if (VMPlanta.Foto.ContentType == "image/jpeg" || VMPlanta.Foto.ContentType == "image/png") {
                                        string extension;
                                        if (VMPlanta.Foto.ContentType == "image/jpeg")
                                        {
                                            extension = ".jpg";
                                        }
                                        else
                                        {
                                            extension = ".png";
                                        }
                                        string nomArchivo = VMPlanta.Planta.nombreCientifico.Replace(" ","_") + "_001"+extension;
                                        VMPlanta.Planta.foto = nomArchivo;
                                        bool altaTP = ManejadorPlanta.AgregarPlanta(VMPlanta.Planta, VMPlanta.idTipoPlanta, VMPlanta.idTipoAmbiente, VMPlanta.idIluminacion);
                                        if (altaTP)
                                        {
                                            string rutaRaiz = WebHostEnvironment.WebRootPath;
                                            string rutaImagenes = Path.Combine(rutaRaiz, "img");//aqui lo une solo sin ver orden e imagenes es la carpeta de imagenes
                                            string rutaArchivo = Path.Combine(rutaImagenes, nomArchivo);
                                            FileStream stream = new FileStream(rutaArchivo, FileMode.Create); //para hacer la ruta un stream
                                            VMPlanta.Foto.CopyTo(stream);
                                            return RedirectToAction(nameof(Index));
                                        }
                                        else
                                        {
                                            throw new Exception("No fue posible el alta de esta nueva Planta.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("El archivo de la foto subida no es válida, tiene que ser extensión jpeg o png.");
                                    }
                                    
                                }
                                else
                                { 
                                    throw new Exception("El campo descripción debe estar entre " + minimaDesc + " y " + maximaDesc + " caracteres.");
                                }
                            }
                            else
                            {
                                throw new Exception("El nombre de la Planta ya existe en la base de datos, ingrese otro.");
                            }
                        }
                        else
                        {
                            throw new Exception("El nombre de la Planta tiene espacios al principio o final y/o tiene números, verifíquelo.");
                        }
                    }                    
                }
                else
                {
                    throw new Exception("Complete todos los campos.");
                }
            }
            catch (Exception ex)            
            {                
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;
                
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
        private void MostrarPlantaAtributos()
        {
            ViewModelPlanta VMPlantasAtr = new ViewModelPlanta();
            VMPlantasAtr.TipoPlanta = ManejadorPlanta.TraerTodosTiposPlantas();
            ViewBag.TipoPlantas = VMPlantasAtr.TipoPlanta;
            VMPlantasAtr.TipoAmbiente = ManejadorPlanta.TraerTodosTiposAmbientes();
            ViewBag.TipoAmbientes = VMPlantasAtr.TipoAmbiente;
            VMPlantasAtr.Iluminacion = ManejadorPlanta.TraerTodosIluminaciones();
            ViewBag.Iluminaciones = VMPlantasAtr.Iluminacion;
        }
    }
}
