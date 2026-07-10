using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_DataAccess.Interfaces;
using Clean_Go_Entities.Servicios;

namespace Clean_Go_DataAccess.Repositories.Servicios
{
    public class ServicioDAL : IRepository<Servicio>
    {
        public List<Servicio> ObtenerTodos()
        {
            List<Servicio> lista = new List<Servicio>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Servicio_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Servicio
                            {
                                ServicioId = Convert.ToInt32(dr["ServicioId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["PrecioBase"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Servicio ObtenerPorId(int id)
        {
            Servicio servicio = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Servicio_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioId", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            servicio = new Servicio
                            {
                                ServicioId = Convert.ToInt32(dr["ServicioId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["PrecioBase"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };
                        }
                    }
                }
            }

            return servicio;
        }

        public bool Crear(Servicio servicio)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Servicio_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)servicio.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioBase", servicio.Precio);

                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }

        public bool Actualizar(Servicio servicio)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Servicio_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ServicioId", servicio.ServicioId);
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)servicio.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioBase", servicio.Precio);
                    cmd.Parameters.AddWithValue("@Estado", servicio.Estado);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Servicio_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioId", id);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }
    }
}
