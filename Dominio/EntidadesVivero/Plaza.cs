using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero

public class Plaza : Compra
{
	public static decimal tasaIVA { get; set; }

	public decimal costoFlete { get; set; }

	public override decimal PrecioFinal() { }
}
