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

        public bool ValidarFormatoNombre(string nombreTP)
        {
            bool errorFormato = false;

            if (nombreTP.Substring(0,1) ==" " || nombreTP.Substring(nombreTP.Length-1, 1) ==" ")
            {
                errorFormato = true;
            }
            else {                               
                for (int i=0;i<nombreTP.Length && !errorFormato; i++) {
                    if (Char.IsNumber(nombreTP[i]) && Char.IsNumber(nombreTP[i])) {
                        errorFormato = true;
                    }                    
                }                
            }

            return errorFormato;
        }

        public TipoPlanta buscarUnaPlanta(int id)
        {
            return RepoTipoPlantas.FindById(id);
        }

        public TipoPlanta buscarPlantaNombre(string nombreTP)
        {
            return RepoTipoPlantas.buscarTipoPlanta(nombreTP);
        }
    }
}
