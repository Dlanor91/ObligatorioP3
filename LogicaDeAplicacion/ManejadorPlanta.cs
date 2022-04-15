using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;


namespace LogicaDeAplicacion
{
    public class ManejadorPlanta : IManejadorPlanta
    {
        public IRepositorioPlantas RepoPlantas { get; set; }

        public ManejadorPlanta(IRepositorioPlantas repoPlantas)
        {
            RepoPlantas = repoPlantas;
        }

        public IEnumerable<Planta> MostrarTodasPlantas()
        {
            return RepoPlantas.FindAll();
        }
    }
}