using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesVivero;
using Microsoft.AspNetCore.Http;

namespace Vivero.Models
{
    public class ViewModelPlanta
    {
        public IEnumerable<TipoPlanta> TipoPlanta { get; set; }
        public IEnumerable<TipoAmbiente> TipoAmbiente { get; set; }
        public IEnumerable<Iluminacion> Iluminacion { get; set; }
    }
}
