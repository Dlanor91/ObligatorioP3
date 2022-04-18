using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioTipoAmbienteADO : IRepositorioTipoAmbiente
    {
        public bool Add(TipoAmbiente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoAmbiente> FindAll()
        {
            List<TipoAmbiente> tipoAmbiente = new List<TipoAmbiente>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoAmbiente;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    TipoAmbiente unTipoAmbiente = new TipoAmbiente()
                    {
                        id = reader.GetInt32(0),
                        tipoAmbiente = reader.GetString(1)
                    };
                    tipoAmbiente.Add(unTipoAmbiente);
                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return tipoAmbiente;
        }

        public TipoAmbiente FindById(int id)
        {
            TipoAmbiente tipoAmbienteBuscado = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoAmbiente WHERE id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    tipoAmbienteBuscado = new TipoAmbiente()
                    {
                        id = reader.GetInt32(0),
                        tipoAmbiente = reader.GetString(1)                        
                    };
                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return tipoAmbienteBuscado;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoAmbiente obj)
        {
            throw new NotImplementedException();
        }
    }
}
