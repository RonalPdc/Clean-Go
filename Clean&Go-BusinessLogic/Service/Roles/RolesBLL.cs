using Clean_Go_DataAccess.Repositories.Roles;
using Clean_Go_Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Go_BusinessLogic.Service.Roles
{
    public class RolesBLL
    {
        private readonly RolDAL _rolDAL = new RolDAL();

        public List<Rol> ObtenerTodos()
        {
            return _rolDAL.ObtenerTodos();
        }

        public Rol ObtenerPorId(int id)
        {
            return _rolDAL.ObtenerPorId(id);
        }

        public bool Crear(Rol rol)
        {
            return _rolDAL.Crear(rol);
        }

        public bool Actualizar(Rol rol)
        {
            return _rolDAL.Actualizar(rol);
        }

        public bool Eliminar(int id)
        {
            return _rolDAL.Eliminar(id);
        }
    }
}