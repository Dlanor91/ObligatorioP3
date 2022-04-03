using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero

public class Item
{
	public int id { get; set; }

	public int cantidad { get; set; }

	public int decimal precioUnitario { get; set; }

	public Planta planta { get; set; }

}
