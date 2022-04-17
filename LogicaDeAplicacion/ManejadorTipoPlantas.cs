using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Repositorios;

namespace LogicaDeAplicacion
{
    public class ManejadorTipoPlantas : IManejadorTipoPlantas
    {
        public IRepositorioTipoPlanta RepoTipoPlantas { get; set; }

        public ManejadorTipoPlantas(IRepositorioTipoPlanta repoTipoPlantas)
        {
            RepoTipoPlantas=repoTipoPlantas;
        }
        
        public bool AgregarTipoPlanta(TipoPlanta tp)
        {           
            return RepoTipoPlantas.Add(tp);
        }

        public IEnumerable<TipoPlanta> MostrarTodosTiposPlantas()
        {
            return RepoTipoPlantas.FindAll();
        }

        public bool ValidarNombreUnico(string nombreTP)
        {
            return RepoTipoPlantas.existeNombre(nombreTP);
        }        

        public TipoPlanta buscarUnaPlanta(int id)
        {
            return RepoTipoPlantas.FindById(id);
        }

        public TipoPlanta buscarPlantaNombre(string nombreTP)
        {
            return RepoTipoPlantas.buscarTipoPlanta(nombreTP);
        }

        public bool actDescripcionTipoPlanta(TipoPlanta tp)
        {
            return RepoTipoPlantas.Update(tp);
        }

        public bool eliminarTipoPlanta(int id)
        {
            return RepoTipoPlantas.Remove(id);
        }
    }
}
