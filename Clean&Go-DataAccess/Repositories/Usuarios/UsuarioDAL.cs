using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go_DataAccess.Repositories.Usuarios
{
    public class UsuarioDAL
    {
        public Usuario Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;

            using (SqlConnection cn = ConexionDB.ObtenerConexion())
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

            using (SqlConnection cn = ConexionDB.ObtenerConexion())
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
                                Rol = dr["Rol"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Usuario ObtenerPorId(int usuarioId)
        {
            Usuario usuario = null;

            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Usuario_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
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
                                PasswordHash = dr["PasswordHash"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
