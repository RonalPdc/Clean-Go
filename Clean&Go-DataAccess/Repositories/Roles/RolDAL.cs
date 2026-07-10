using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go_DataAccess.Interfaces;
using Clean_Go_Entities.Roles;

namespace Clean_Go_DataAccess.Repositories.Roles
{
    public class RolDAL : IRepository<Rol>
    {
        public List<Rol> ObtenerTodos()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Rol_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol
                            {
                                RolId = Convert.ToInt32(dr["RolId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Rol ObtenerPorId(int id)
        {
            Rol rol = null;

            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Rol_GetById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            rol = new Rol
                            {
                                RolId = Convert.ToInt32(dr["RolId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };
                        }
                    }
                }
            }

            return rol;
        }

        public bool Crear(Rol rol)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Rol_Create", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion);

                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Actualizar(Rol rol)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Rol_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RolId", rol.RolId);
                    cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", rol.Estado);

                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("Rol_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", id);

                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
