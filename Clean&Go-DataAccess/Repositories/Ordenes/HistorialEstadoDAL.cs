using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_Entities.Ordenes;

namespace Clean_Go_DataAccess.Repositories.Ordenes
{
    public class HistorialEstadoDAL
    {
        public List<HistorialEstado> ObtenerPorOrden(int ordenId)
        {
            List<HistorialEstado> lista = new List<HistorialEstado>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("HistorialEstados_GetByOrden", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdenId", ordenId);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new HistorialEstado
                            {
                                HistorialId = Convert.ToInt32(dr["HistorialId"]),
                                OrdenId = Convert.ToInt32(dr["OrdenId"]),
                                EstadoAnteriorId = dr["EstadoAnteriorId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EstadoAnteriorId"]),
                                EstadoNuevoId = Convert.ToInt32(dr["EstadoNuevoId"]),
                                FechaHora = Convert.ToDateTime(dr["Fecha"]),
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public bool RegistrarCambio(int ordenId, int? estadoAnteriorId, int estadoNuevoId, int usuarioId, string comentario)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("HistorialEstados_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrdenId", ordenId);
                    cmd.Parameters.AddWithValue("@EstadoAnteriorId", (object)estadoAnteriorId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoNuevoId", estadoNuevoId);
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@Comentario", (object)comentario ?? DBNull.Value);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }
    }
}
