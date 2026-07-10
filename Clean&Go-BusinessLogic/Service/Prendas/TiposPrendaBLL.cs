using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Prendas;
using Clean_Go_Entities.Prendas;

namespace Clean_Go_BusinessLogic.Service.Prendas
{
    public class TiposPrendaBLL
    {
        private readonly TipoPrendaDAL _prendaDAL = new TipoPrendaDAL();

        public List<TipoPrenda> ObtenerTodos()
        {
            return _prendaDAL.ObtenerTodos();
        }

        public TipoPrenda ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de tipo de prenda inválido.");

            return _prendaDAL.ObtenerPorId(id);
        }

        public bool Crear(TipoPrenda prenda)
        {
            ValidarPrenda(prenda);
            return _prendaDAL.Crear(prenda);
        }

        public bool Actualizar(TipoPrenda prenda)
        {
            if (prenda.TipoPrendaId <= 0)
                throw new ArgumentException("ID de tipo de prenda inválido.");

            ValidarPrenda(prenda);
            return _prendaDAL.Actualizar(prenda);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de tipo de prenda inválido.");

            return _prendaDAL.Eliminar(id);
        }

        private void ValidarPrenda(TipoPrenda prenda)
        {
            if (prenda == null)
                throw new ArgumentNullException(nameof(prenda));

            if (string.IsNullOrWhiteSpace(prenda.Nombre))
                throw new ArgumentException("El nombre del tipo de prenda es obligatorio.");
        }
    }
}
