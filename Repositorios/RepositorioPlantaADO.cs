using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioPlantaADO : IRepositorioPlantas
    {
        public bool Add(Planta obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planta> buscarPlantasTipoAmbiente(int tipoAmbiente)
        {
            List<Planta> plantas = new List<Planta>();
            
            SqlConnection con = Conexion.ObtenerConexion();
            
            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.tipoAmbiente = @tipoAmbiente;";
            
            SqlCommand com = new SqlCommand(sql, con);            
            com.Parameters.AddWithValue("@tipoAmbiente", tipoAmbiente );
            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantas.Add(p);
                }

                Conexion.CerrarConexion(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }
            
            return plantas;
        }

        public IEnumerable<Planta> buscarPlantaMayorAlt(decimal altura)
        {
            List<Planta> plantasMayores = new List<Planta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.alturaMax >= @altura;";
            SqlCommand com = new SqlCommand(sql, con);            
            com.Parameters.AddWithValue("@altura", altura);
            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantasMayores.Add(p);
                }

                Conexion.CerrarConexion(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return plantasMayores;
        }

        public IEnumerable<Planta> buscarPlantaMenorAlt(decimal altura)
        {
            List<Planta> plantasMenores = new List<Planta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.alturaMax <= @altura;";
            SqlCommand com = new SqlCommand(sql, con);            
            com.Parameters.AddWithValue("@altura", altura);
            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantasMenores.Add(p);
                }

                Conexion.CerrarConexion(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return plantasMenores;
        }

        public IEnumerable<Planta> buscarPlantaNombre(string nombreBusqPlanta)
        {
            List<Planta> plantas = new List<Planta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.nombreCientifico like @nombreBusqPlanta or pl.nombreVulgares like @nombreBusqPlanta;";
            SqlCommand com = new SqlCommand(sql, con);
            nombreBusqPlanta = "%" + nombreBusqPlanta + "%";
            com.Parameters.AddWithValue("@nombreBusqPlanta", nombreBusqPlanta);
            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantas.Add(p);
                }

                Conexion.CerrarConexion(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return plantas;
        }

        public IEnumerable<Planta> buscarTipoPlanta(int TipoPlanta)
        {
            List<Planta> plantas = new List<Planta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.tipoPlanta = @tipoPlanta;";

            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@tipoPlanta", TipoPlanta);
            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantas.Add(p);
                }

                Conexion.CerrarConexion(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return plantas;
        }

        public IEnumerable<Planta> FindAll()
        {
            List<Planta> plantas = new List<Planta>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id ";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Planta p = CrearPlanta(reader);                    
                    p.tipoAmbiente = CrearTipoAmbiente(reader);
                    p.tipoPlanta = CrearTipoPlanta(reader);
                    p.tipoIlumincacion = CrearIluminacion(reader);
                    plantas.Add(p);   
                }

                Conexion.CerrarConexion(con);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return plantas;
        }

        private Iluminacion CrearIluminacion(SqlDataReader reader)
        {
            return new Iluminacion()
            {
                tipoIluminacion = reader.GetString(9)
            };
        }

        private TipoPlanta CrearTipoPlanta(SqlDataReader reader)
        {
            return new TipoPlanta() {
                nombre = reader.GetString(8)
            };
        }

        private TipoAmbiente CrearTipoAmbiente(SqlDataReader reader)
        {
            return new TipoAmbiente()
            {
                tipoAmbiente = reader.GetString(5)
            };
        }

        private Planta CrearPlanta(SqlDataReader reader)
        {
            Planta p = new Planta();
            p.id = reader.GetInt32(0);
            p.nombreCientifico = reader.GetString(1);
            p.descripcionPlanta = reader.GetString(2);
            p.alturaMax = reader.GetDecimal(3);
            p.foto = reader.GetString(4);
            p.frecuenciaRiego = reader.GetString(6);
            p.temperatura = reader.GetDecimal(7);
            p.nombresVulgares = reader.GetString(10);
            return p;
        }
        public Planta FindById(int id)
        {
            Planta plantaEncontrada = new Planta();
            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select pl.id, pl.nombreCientifico, pl.descripcionPlanta, pl.alturaMax, pl.foto, ta.tipoAmbiente, pl.frecuenciaRiego, pl.temperatura, tp.nombre,il.tipoIluminacion,pl.nombreVulgares from Planta pl " +
                         "left join TipoAmbiente ta on pl.tipoAmbiente = ta.id " +
                         "left join TipoPlanta tp on pl.tipoPlanta = tp.id " +
                         "left join Iluminacion il on pl.tipoIluminacion = il.id " +
                         "where pl.id = @id; ";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {                    
                    Planta pl = CrearPlanta(reader);
                    pl.tipoAmbiente = CrearTipoAmbiente(reader);
                    pl.tipoPlanta = CrearTipoPlanta(reader);
                    pl.tipoIlumincacion = CrearIluminacion(reader);
                    plantaEncontrada = pl;
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

            return plantaEncontrada;
        }


        public bool Remove(int id)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "DELETE FROM Planta WHERE Id=@id;";
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

        public bool Update(Planta obj)
        {
            throw new NotImplementedException();
        }
    }
}
