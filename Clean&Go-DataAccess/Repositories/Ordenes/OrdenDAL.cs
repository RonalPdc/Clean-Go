using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_Entities.Ordenes;

namespace Clean_Go_DataAccess.Repositories.Ordenes
{
    public class OrdenDAL
    {
        public List<Orden> ObtenerTodos()
        {
            List<Orden> lista = new List<Orden>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Orden_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Orden
                            {
                                OrdenId = Convert.ToInt32(dr["OrdenId"]),
                                NumeroOrden = dr["NumeroOrden"].ToString(),
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                FechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]),
                                FechaEntregaEstimada = Convert.ToDateTime(dr["FechaEntregaEstimada"]),
                                Observaciones = dr["Observaciones"].ToString(),
                                Total = Convert.ToDecimal(dr["Total"]),
                                EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                UsuarioRegistroId = Convert.ToInt32(dr["UsuarioRegistroId"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Orden ObtenerPorId(int id)
        {
            Orden orden = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Orden_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdenId", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orden = new Orden
                            {
                                OrdenId = Convert.ToInt32(dr["OrdenId"]),
                                NumeroOrden = dr["NumeroOrden"].ToString(),
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                FechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]),
                                FechaEntregaEstimada = Convert.ToDateTime(dr["FechaEntregaEstimada"]),
                                Observaciones = dr["Observaciones"].ToString(),
                                Total = Convert.ToDecimal(dr["Total"]),
                                EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                UsuarioRegistroId = Convert.ToInt32(dr["UsuarioRegistroId"])
                            };
                        }
                    }
                }
            }

            return orden;
        }

        public bool ActualizarEstado(int ordenId, int nuevoEstadoId, int usuarioId, string comentario)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Orden_UpdateEstado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdenId", ordenId);
                    cmd.Parameters.AddWithValue("@EstadoNuevo", nuevoEstadoId);
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@Comentario", (object)comentario ?? DBNull.Value);

                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }

        public bool CrearOrden(Orden orden, List<DetalleOrden> detalles)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                cn.Open();
                
                using (SqlTransaction transaction = cn.BeginTransaction())
                {
                    try
                    {
                        int nuevaOrdenId = 0;

                        using (SqlCommand cmdOrden = new SqlCommand("Orden_Create", cn, transaction))
                        {
                            cmdOrden.CommandType = CommandType.StoredProcedure;
                            cmdOrden.Parameters.AddWithValue("@NumeroOrden", orden.NumeroOrden);
                            cmdOrden.Parameters.AddWithValue("@ClienteId", orden.ClienteId);
                            cmdOrden.Parameters.AddWithValue("@FechaEntregaEstimada", orden.FechaEntregaEstimada);
                            cmdOrden.Parameters.AddWithValue("@Observaciones", (object)orden.Observaciones ?? DBNull.Value);
                            cmdOrden.Parameters.AddWithValue("@UsuarioRegistroId", orden.UsuarioRegistroId);

                            object res = cmdOrden.ExecuteScalar();
                            if (res == null || res == DBNull.Value)
                            {
                                throw new Exception("Error al crear la cabecera de la orden.");
                            }
                            nuevaOrdenId = Convert.ToInt32(res);
                        }

                        foreach (var det in detalles)
                        {
                            using (SqlCommand cmdDet = new SqlCommand("DetalleOrden_Create", cn, transaction))
                            {
                                cmdDet.CommandType = CommandType.StoredProcedure;
                                cmdDet.Parameters.AddWithValue("@OrdenId", nuevaOrdenId);
                                cmdDet.Parameters.AddWithValue("@TipoPrendaId", det.TipoPrendaId);
                                cmdDet.Parameters.AddWithValue("@ServicioId", det.ServicioId);
                                cmdDet.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                                cmdDet.Parameters.AddWithValue("@Precio", det.Precio);
                                cmdDet.Parameters.AddWithValue("@Observaciones", (object)det.Observaciones ?? DBNull.Value);

                                cmdDet.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        orden.OrdenId = nuevaOrdenId;
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Dictionary<int, int> ObtenerConteosPorEstado()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic[1] = 0;             dic[2] = 0;             dic[3] = 0;             dic[4] = 0; 
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                string sql = "SELECT EstadoId, COUNT(*) AS Cantidad FROM Ordenes GROUP BY EstadoId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int estadoId = Convert.ToInt32(dr["EstadoId"]);
                            int cantidad = Convert.ToInt32(dr["Cantidad"]);
                            dic[estadoId] = cantidad;
                        }
                    }
                }
            }
            return dic;
        }

        public DataTable ObtenerReporteOrdenes(DateTime? desde, DateTime? hasta, string estado)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Orden_GetReporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Desde", (object)desde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Hasta", (object)hasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(estado) ? "Todos" : estado);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public List<string> ObtenerTodosEstados()
        {
            List<string> lista = new List<string>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("EstadosOrden_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(dr["Nombre"].ToString());
                        }
                    }
                }
            }

            return lista;
        }
    }
}
