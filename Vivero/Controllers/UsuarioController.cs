﻿using Dominio.EntidadesVivero;
using LogicaDeAplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero.Controllers
{
    public class UsuarioController : Controller
    {
        public IManejadorUsuario ManejadorUsuario { get; set; }

        public UsuarioController(IManejadorUsuario manejadorUsuario)
        {
            ManejadorUsuario=manejadorUsuario;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(string nombreUsuario, string contrasenia)
        {
            try
            {
                if (nombreUsuario == null || contrasenia == null)
                {
                    throw new Exception("Complete todos los campos.");
                }
                else
                {
                    if (contrasenia.Length<6) {
                        throw new Exception("La contraseña debe tener un mínimo de 6 caracteres.");
                    }
                    else {
                        Usuario logueado = ManejadorUsuario.IngresoExitoso(nombreUsuario, contrasenia);
                        if (logueado !=null)
                        {
                            HttpContext.Session.SetString("datosNombreUsuario", logueado.nombreUsuario);
                            HttpContext.Session.SetString("datosNombreCompleto", logueado.Nombre + " " + logueado.Apellido);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            throw new Exception("El usuario o contraseña ingresado no están en nuestra base de batos.");
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
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult CerrarSession()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                HttpContext.Session.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
