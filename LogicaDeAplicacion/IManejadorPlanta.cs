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
        public IEnumerable<Planta> buscarPlantasTipoAmbiente(int idTipoAmbiente);
        public IEnumerable<Planta> buscarPlantasTipoPlanta(int idTipoPlanta);
        public IEnumerable<TipoPlanta> TraerTodosTiposPlantas();
        public IEnumerable<TipoAmbiente> TraerTodosTiposAmbientes();
        public IEnumerable<Iluminacion> TraerTodosIluminaciones();
        public bool AgregarPlanta(Planta p);
    }
}