using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_DataAccess.Interfaces;
using Clean_Go_Entities.Clientes;

namespace Clean_Go_DataAccess.Repositories.Clientes
{
    public class ClienteDAL : IRepository<Cliente>
    {
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Cliente_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Cedula = dr["Cedula"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                TelegramChatId = dr["TelegramChatId"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Cliente_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Cedula = dr["Cedula"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                TelegramChatId = dr["TelegramChatId"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };
                        }
                    }
                }
            }

            return cliente;
        }

        public bool Crear(Cliente cliente)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Cliente_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TelegramChatId", (object)cliente.TelegramChatId ?? DBNull.Value);

                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Cliente_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TelegramChatId", (object)cliente.TelegramChatId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

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
                using (SqlCommand cmd = new SqlCommand("Cliente_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);

                    cn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    return rows == -1 || rows > 0;
                }
            }
        }
    }
}
