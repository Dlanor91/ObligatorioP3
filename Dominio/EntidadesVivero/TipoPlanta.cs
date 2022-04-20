using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class TipoPlanta : IValidar
    {
        public int id { get; set;}

        public string nombre { get; set; }

        public string descripcionTipo { get; set; }

        public bool Validar()
        {
            bool valido = false;
            if (nombre != null && descripcionTipo!= null)
            {
                valido = true;
            }

            return valido;
        }
               
        public bool ValidarDescripcion(string descripcion, int minimoDesc, int maxDesc)
        {
            bool descripcionValida = false;
            if (descripcion.Length>=minimoDesc && descripcion.Length<=maxDesc) {
                descripcionValida = true;
            } 
            return descripcionValida;
        }

        public bool ValidarFormatoNombre(string nombre)
        {
          bool errorFormato = false;

            if (nombre.Substring(0, 1) ==" " || nombre.Substring(nombre.Length-1, 1) ==" ")
            {
                errorFormato = true;
            }
            else
            {
                for (int i = 0; i<nombre.Length && !errorFormato; i++)
                {
                    if (Char.IsNumber(nombre[i]) && Char.IsNumber(nombre[i]))
                    {
                        errorFormato = true;
                    }
                }
            }

            return errorFormato;
        }

    }
    
}
