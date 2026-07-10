using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Servicios;
using Clean_Go_Entities.Servicios;

namespace Clean_Go_BusinessLogic.Service.Servicios
{
    public class ServiciosBLL
    {
        private readonly ServicioDAL _servicioDAL = new ServicioDAL();

        public List<Servicio> ObtenerTodos()
        {
            return _servicioDAL.ObtenerTodos();
        }

        public Servicio ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de servicio inválido.");

            return _servicioDAL.ObtenerPorId(id);
        }

        public bool Crear(Servicio servicio)
        {
            ValidarServicio(servicio);
            return _servicioDAL.Crear(servicio);
        }

        public bool Actualizar(Servicio servicio)
        {
            if (servicio.ServicioId <= 0)
                throw new ArgumentException("ID de servicio inválido.");

            ValidarServicio(servicio);
            return _servicioDAL.Actualizar(servicio);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de servicio inválido.");

            return _servicioDAL.Eliminar(id);
        }

        private void ValidarServicio(Servicio servicio)
        {
            if (servicio == null)
                throw new ArgumentNullException(nameof(servicio));

            if (string.IsNullOrWhiteSpace(servicio.Nombre))
                throw new ArgumentException("El nombre del servicio es obligatorio.");

            if (servicio.Precio < 0)
                throw new ArgumentException("El precio del servicio no puede ser negativo.");
        }
    }
}
