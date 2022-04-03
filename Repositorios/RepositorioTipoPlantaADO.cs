using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;

namespace Repositorios
{

    public class RepositorioTipoPlantaADO : IRepositorioTipoPlanta   

    {
        public bool Add(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
        
        public TipoPlanta buscarTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool eliminarTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            throw new NotImplementedException();
        }

        public TipoPlanta FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool modificarDesripcionTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}
