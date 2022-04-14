﻿using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;

namespace LogicaDeAplicacion
{
    public interface IManejadorTipoPlantas
    {
        public IEnumerable<TipoPlanta> MostrarTodosTiposPlantas();
        bool AgregarTipoPlanta(TipoPlanta tp);
        bool ValidarNombreUnico(string nombreTP);
        bool ValidarFormatoNombre(string nombreTP);
        public TipoPlanta buscarUnaPlanta(int id);
    }
}
