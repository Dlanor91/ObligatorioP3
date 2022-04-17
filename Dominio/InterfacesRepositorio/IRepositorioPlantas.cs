using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPlantas:IRepositorio<Planta>
    {
        IEnumerable<Planta> buscarPlantaNombre(string nombreBusqPlanta);
        IEnumerable<Planta> buscarTipoPlanta(int TipoPlanta);
        IEnumerable<Planta> buscarPlantasTipoAmbiente(int tipoAmbiente);
        IEnumerable<Planta> buscarPlantaMenorAlt(decimal altura);
        IEnumerable<Planta> buscarPlantaMayorAlt(decimal altura);
        bool existeNombre(string nombreCPlanta);
    }
}
