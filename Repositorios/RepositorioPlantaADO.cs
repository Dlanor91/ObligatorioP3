using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;

namespace Repositorios
{
    public class RepositorioPlantaADO : IRepositorioPlantas
    {
        public bool Add(Planta obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarAmbiente(int tipoAmbiente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaMayorAlt(decimal altura)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaMenorAlt(decimal altura)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantaNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarTipoPlanta(int TipoPlanta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> FindAll()
        {
            throw new NotImplementedException();
        }

        public Planta FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Planta obj)
        {
            throw new NotImplementedException();
        }
    }
}
