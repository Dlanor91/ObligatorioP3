using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
   public abstract class Compra
    {
        public int id { get; set; }

        public DateTime fechaCompra { get; set; }

        public List<Item> items { get; set; }

        public abstract decimal PrecioFinal(); 
    }
}
