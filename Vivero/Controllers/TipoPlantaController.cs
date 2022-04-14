﻿using Microsoft.AspNetCore.Http;
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
            TipoPlanta tpNew = new TipoPlanta();
            return View(tpNew);
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
                                    ViewBag.Error = "No fue posible el alta de un nuevo Tipo de Planta.";
                                    return View();
                                }
                            }
                            else
                            {
                                ViewBag.Error = "El campo descripción debe estar entre 10 y 200 caracteres.";
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Error = "El nombre del Tipo de Planta ya existe en la base de datos, ingrese otro.";
                            return View();
                        }
                    }
                    else {
                        ViewBag.Error = "El nombre del Tipo de Planta tiene espacios embebidos o tiene números, verifíquelo.";
                        return View();
                    }                    
                }
                else {
                    ViewBag.Error = "Complete todos los campos.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoPlanta tpEdit = ManejadorTipoPlantas.buscarUnaPlanta(id);
            return View(tpEdit);
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
