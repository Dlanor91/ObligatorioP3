using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioIluminacionADO : IRepositorioIluminacion
    {
        public bool Add(Iluminacion obj)
        {
            bool listo = false;

            SqlConnection con = Conexion.ObtenerConexion();
            string sql = "INSERT INTO Iluminacion VALUES(@tipoIluminacion);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@tipoIluminacion", obj.tipoIluminacion);            

            SqlTransaction transaccion = null;

            try
            {
                Conexion.AbrirConexion(con);
                transaccion = con.BeginTransaction();
                com.Transaction = transaccion;
                int filasAfectadas = com.ExecuteNonQuery();
                listo = filasAfectadas == 1;
                transaccion.Commit();
                Conexion.CerrarConexion(con);
            }
            catch
            {
                if (transaccion != null) transaccion.Rollback();
                listo = false;

            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return listo;
        }

        public bool Remove(int id)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "DELETE FROM Iluminacion WHERE Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                int filasAfectadas = com.ExecuteNonQuery();
                ok = filasAfectadas == 1;
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

            return ok;
        }

        public bool Update(Iluminacion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Iluminacion> FindAll()
        {
            List<Iluminacion> Iluminaciones = new List<Iluminacion>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Iluminacion;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Iluminacion unaIluminacion = new Iluminacion()
                    {
                        id = reader.GetInt32(0),
                        tipoIluminacion = reader.GetString(1)                        
                    };
                    Iluminaciones.Add(unaIluminacion);
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

            return Iluminaciones;
        }

        public Iluminacion FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}