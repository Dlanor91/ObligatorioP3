using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using Repositorios;


namespace LogicaDeAplicacion
{
    public class ManejadorPlanta : IManejadorPlanta
    {
        public IRepositorioPlantas RepoPlantas { get; set; }
        public IRepositorioTipoPlanta RepoTipoPlantas { get; set; }
        public IRepositorioTipoAmbiente RepoTipoAmbientes { get; set; }
        public IRepositorioIluminacion RepoIluminacion { get; set; }

        public ManejadorPlanta(IRepositorioPlantas repoPlantas, IRepositorioTipoPlanta repoTipoPlantas, IRepositorioTipoAmbiente repoTipoAmbientes, IRepositorioIluminacion repoIluminacion)
        {
            RepoPlantas=repoPlantas;
            RepoTipoPlantas=repoTipoPlantas;
            RepoTipoAmbientes=repoTipoAmbientes;
            RepoIluminacion=repoIluminacion;
        }

        public IEnumerable<Planta> MostrarTodasPlantas()
        {
            return RepoPlantas.FindAll();
        }

        public IEnumerable<Planta> BusquedaNombre(string nombreBusqPlanta)
        {
            return RepoPlantas.buscarPlantaNombre(nombreBusqPlanta);
        }

        public IEnumerable<Planta> buscarPlantasMenoresAlt(decimal alturaBuscar)
        {
            return RepoPlantas.buscarPlantaMenorAlt(alturaBuscar);
        }

        public IEnumerable<Planta> buscarPlantasMayoresAlt(decimal alturaBuscar)
        {
            return RepoPlantas.buscarPlantaMayorAlt(alturaBuscar);
        }

        public IEnumerable<Planta> buscarPlantasTipoAmbiente(int idTipoAmbiente)
        {
            return RepoPlantas.buscarPlantasTipoAmbiente(idTipoAmbiente);
        }

        public IEnumerable<Planta> buscarPlantasTipoPlanta(int idTipoPlanta)
        {
            return RepoPlantas.buscarTipoPlanta(idTipoPlanta);
        }

        public IEnumerable<TipoPlanta> TraerTodosTiposPlantas()
        {
            return RepoTipoPlantas.FindAll();
        }

        public IEnumerable<TipoAmbiente> TraerTodosTiposAmbientes()
        {
            return RepoTipoAmbientes.FindAll();
        }

        public IEnumerable<Iluminacion> TraerTodosIluminaciones()
        {
            return RepoIluminacion.FindAll();
        }

        public bool AgregarPlanta(Planta p)
        {
            return RepoPlantas.Add(p);
        }

        public bool verificarNombreC(string nombreC)
        {
            return RepoPlantas.existeNombre(nombreC);
        }
    }
}