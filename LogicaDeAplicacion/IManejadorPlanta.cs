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
        public IEnumerable<Planta> BusquedaNombre(string nombreBusqPlanta);
        public IEnumerable<Planta> buscarPlantasMenoresAlt(decimal alturaBuscar);
        public IEnumerable<Planta> buscarPlantasMayoresAlt(decimal alturaBuscar);
    }
}