using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesVivero
{
    public class Usuario
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public int ValidarUsuario() {

            int error = 1; //esta bien todo

            if (Email == null || Contrasenia == null)
            {
                error = -1; //campos vacio
            }
            else if (Email.IndexOf("@")==-1)
            {
                error = -2; //email sin @
            }
            else if (Contrasenia.Length<6)
            {
                error = -3; //contrasenia con menos de 6 caracteres
            }
            else if(!VerificarContrasenna(Contrasenia))
            {
                error = -4; //no cumple los requisitos de validacion de contrasenia
            }


            return error;
        }

        private bool VerificarContrasenna(string Contrasenia)
        {
            bool ret = false;

            //validacion mayuscula 65 al 90 ascii y validacion de minuscula 97 al 122 ascii
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneNumero = false;
            foreach (char c in Contrasenia)
            {
                int n = (int)c;

                if (n >= 65 && n <= 90)
                {
                    tieneMayuscula = true;
                }
                else if (n >= 97 && n <= 122) {

                    tieneMinuscula = true;
                }
            }

            if (tieneMayuscula && tieneMinuscula)
            {
                //validacion numerica 48 al 57 ascii                
                foreach (char c in Contrasenia)
                {
                    int n = (int)c;

                    if (n >= 48 && n <= 57)
                    {
                        tieneNumero = true;
                        ret = true;
                    }
                }
            }            

            return ret;
        } 

    }
}
