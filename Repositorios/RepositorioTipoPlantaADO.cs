using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{

    public class RepositorioTipoPlantaADO : IRepositorioTipoPlanta   

    {
        public bool Add(TipoPlanta obj)
        {
            bool listo = false;

            SqlConnection conect = Conexion.ObtenerConexion();
            string sql = "INSERT INTO TipoPlanta VALUES(@nombre,@desc);";
            SqlCommand com = new SqlCommand(sql, conect);

            com.Parameters.AddWithValue("@nombre",obj.nombre);
            com.Parameters.AddWithValue("@desc", obj.descripcionTipo);

            SqlTransaction transaccion = null;

            try
            {
                Conexion.AbrirConexion(conect);
                transaccion = conect.BeginTransaction();
                com.Transaction = transaccion;
                int filasAfectadas = com.ExecuteNonQuery();
                listo = filasAfectadas == 1;
                transaccion.Commit();
                Conexion.CerrarConexion(conect);

            }
            catch
            {
                if (transaccion != null) transaccion.Rollback();
               
            }
            finally 
            {
                Conexion.CerrarYDisposeConexion(conect);
            }

            return listo;
        }
        
        public TipoPlanta buscarTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool eliminarTipoPlanta(string nombreTipo)
        {
            bool listo = false;
            return listo;
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            List<TipoPlanta> tipoPlantas = new List<TipoPlanta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoPlanta;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    TipoPlanta tp = new TipoPlanta()
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        descripcionTipo = reader.GetString(2)                        
                    };
                    tipoPlantas.Add(tp);   
                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarConexion(con);
            }

            return tipoPlantas;
        }

        public TipoPlanta FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool modificarDesripcionTipoPlanta(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}
