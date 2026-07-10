using System.Collections.Generic;

namespace Clean_Go_DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        bool Crear(T entidad);
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }
}
