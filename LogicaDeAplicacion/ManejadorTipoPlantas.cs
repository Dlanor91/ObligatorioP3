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
    }
}
