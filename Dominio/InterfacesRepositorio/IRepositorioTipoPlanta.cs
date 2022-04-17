using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioTipoPlanta:IRepositorio<TipoPlanta>
    {
        TipoPlanta buscarTipoPlanta(string nombreTipo);

        bool existeNombre(string nombreTipoPlanta);
        
    }
}
