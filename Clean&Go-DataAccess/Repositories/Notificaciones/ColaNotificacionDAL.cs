using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_Entities.Notificaciones;

namespace Clean_Go_DataAccess.Repositories.Notificaciones
{
    public class ColaNotificacionDAL
    {
        public List<ColaNotificacion> ObtenerPendientes()
        {
            List<ColaNotificacion> lista = new List<ColaNotificacion>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Notificacion_GetPendientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ColaNotificacion
                            {
                                NotificacionId = Convert.ToInt32(dr["NotificacionId"]),
                                OrdenId = Convert.ToInt32(dr["OrdenId"]),
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                TelegramChatId = dr["TelegramChatId"].ToString(),
                                Mensaje = dr["Mensaje"].ToString(),
                                Intentos = Convert.ToInt32(dr["Intentos"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public bool RegistrarNotificacion(int ordenId, int clienteId, string mensaje)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Notificacion_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdenId", ordenId);
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    cmd.Parameters.AddWithValue("@Mensaje", mensaje);

                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }

        public bool MarcarComoEnviada(int notificacionId)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Notificacion_MarcarEnviada", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NotificacionId", notificacionId);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }

        public bool AumentarIntento(int notificacionId)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Notificacion_AumentarIntento", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NotificacionId", notificacionId);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }
    }
}
