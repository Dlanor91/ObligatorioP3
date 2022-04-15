using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorPlanta
    {
        public IEnumerable<Planta> MostrarTodasPlantas();
    }
}