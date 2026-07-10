using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_DataAccess.Interfaces;
using Clean_Go_Entities.Prendas;

namespace Clean_Go_DataAccess.Repositories.Prendas
{
    public class TipoPrendaDAL : IRepository<TipoPrenda>
    {
        public List<TipoPrenda> ObtenerTodos()
        {
            List<TipoPrenda> lista = new List<TipoPrenda>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("TipoPrenda_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipoPrenda
                            {
                                TipoPrendaId = Convert.ToInt32(dr["TipoPrendaId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public TipoPrenda ObtenerPorId(int id)
        {
            TipoPrenda prenda = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("TipoPrenda_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPrendaId", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            prenda = new TipoPrenda
                            {
                                TipoPrendaId = Convert.ToInt32(dr["TipoPrendaId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };
                        }
                    }
                }
            }

            return prenda;
        }

        public bool Crear(TipoPrenda prenda)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("TipoPrenda_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", prenda.Nombre);

                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }

        public bool Actualizar(TipoPrenda prenda)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("TipoPrenda_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TipoPrendaId", prenda.TipoPrendaId);
                    cmd.Parameters.AddWithValue("@Nombre", prenda.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", prenda.Estado);

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
                using (SqlCommand cmd = new SqlCommand("TipoPrenda_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPrendaId", id);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }
    }
}
