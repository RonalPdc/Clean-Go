using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_DataAccess.Interfaces;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go_DataAccess.Repositories.Usuarios
{
    public class UsuarioDAL : IRepository<Usuario>
    {
        public bool Crear(Usuario usuario)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RolId", usuario.RolId);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);

                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }
        public bool Actualizar(Usuario usuario)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                    cmd.Parameters.AddWithValue("@RolId", usuario.RolId);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

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
                using (SqlCommand cmd = new SqlCommand("Usuario_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UsuarioId", id);

                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Usuario Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_Login", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@PasswordHash", contraseña);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NombreUsuario = dr["Usuario"].ToString(),
                                RolId = Convert.ToInt32(dr["RolId"]),
                                Rol = dr["Rol"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NombreUsuario = dr["Usuario"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Rol = dr["Rol"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NombreUsuario = dr["Usuario"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                RolId = Convert.ToInt32(dr["RolId"]),
                                PasswordHash = dr["PasswordHash"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public bool ActualizarPassword(int usuarioId, string nuevoPasswordHash)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET PasswordHash = @PasswordHash WHERE UsuarioId = @UsuarioId", cn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@PasswordHash", nuevoPasswordHash);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
