using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Quala.Data;
using Quala.Interfaces;
using Quala.Models;

namespace Quala.Services
{
    /// <summary>
    /// Servicio para la gestión de monedas.
    /// </summary>
    public class MonedaService : IMonedaRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del servicio de monedas.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public MonedaService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Crea una nueva moneda.
        /// </summary>
        /// <param name="moneda">Datos de la moneda a crear.</param>
        /// <returns>La nueva moneda creada.</returns>
        public MonedaDTO Create(MonedaDTO moneda)
        {
            if (moneda == null)
            {
                throw new ArgumentNullException(nameof(moneda));
            }

            _context.Monedas.Add(moneda);
            _context.SaveChanges();

            return moneda;
        }

        /// <summary>
        /// Elimina una moneda por su ID.
        /// </summary>
        /// <param name="id">ID de la moneda a eliminar.</param>
        /// <returns>True si la moneda se eliminó correctamente.</returns>
        public bool Delete(int id)
        {
            var moneda = _context.Monedas.Find(id);

            if (moneda == null)
            {
                throw new Exception("La moneda no existe.");
            }

            _context.Monedas.Remove(moneda);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Obtiene todas las monedas.
        /// </summary>
        /// <returns>Lista de monedas.</returns>
        public IEnumerable<MonedaDTO> GetAll()
        {
            return _context.Monedas;
        }

        /// <summary>
        /// Obtiene una moneda por su ID.
        /// </summary>
        /// <param name="id">ID de la moneda.</param>
        /// <returns>La moneda correspondiente al ID.</returns>
        public MonedaDTO GetById(int id)
        {
            return _context.Monedas.Find(id);
        }

        /// <summary>
        /// Actualiza una moneda existente.
        /// </summary>
        /// <param name="id">ID de la moneda a actualizar.</param>
        /// <param name="moneda">Datos actualizados de la moneda.</param>
        /// <returns>La moneda actualizada.</returns>
        public MonedaDTO Update(int id, MonedaDTO moneda)
        {
            if (moneda == null)
            {
                throw new ArgumentNullException(nameof(moneda));
            }

            var existingMoneda = _context.Monedas.Find(id);

            if (existingMoneda == null)
            {
                throw new Exception("La moneda no existe.");
            }

            // Actualiza los campos de la moneda con los nuevos valores
            existingMoneda.Nombre = moneda.Nombre;
            existingMoneda.Simbolo = moneda.Simbolo;

            _context.SaveChanges();

            return existingMoneda;
        }
    }
}
