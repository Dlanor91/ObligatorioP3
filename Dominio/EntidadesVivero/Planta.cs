using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class Planta :IValidar
    {
        public int id { get; set; }

        public string nombreCientifico { get; set; }

        public string descripcionPlanta { get; set; }

        public decimal alturaMax { get; set; }

        public string foto { get; set; }

        public TipoAmbiente tipoAmbiente { get; set; }

        public string frecuenciaRiego { get; set; }

        public decimal temperatura { get; set; }

        public TipoPlanta tipoPlanta { get; set; }

        public Iluminacion tipoIlumincacion { get; set; }

        public string nombresVulgares { get; set; }

        public bool Validar()
        {
            bool plantaValida = false;

            if (nombreCientifico != null && descripcionPlanta != null && foto != null && frecuenciaRiego != null && nombresVulgares != null)
            {
                plantaValida = true;
            }

            return plantaValida;
        }


        public bool ValidarDescripcion(string descripcion)
        {
            bool descripcionValida = false;

            if (descripcion.Length >= 10 && descripcion.Length <= 500)
            {
                descripcionValida = true;
            }

            return descripcionValida;
        }


        public bool ValidarFormatoNombre(string nombre)
        {
            bool errorFormato = false;

            if (nombre.Substring(0, 1) == " " || nombre.Substring(nombre.Length - 1, 1) == " ")
            {
                errorFormato = true;
            }
            else
            {
                for (int i = 0; i < nombre.Length && !errorFormato; i++)
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