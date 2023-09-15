using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Quala.Data;
using Quala.Interfaces;
using Quala.Models;

namespace Quala.Services
{
    /// <summary>
    /// Servicio para la gestión de sucursales.
    /// </summary>
    public class SucursalService : ISucursalService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del servicio de sucursales.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public SucursalService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Crea una nueva sucursal.
        /// </summary>
        /// <param name="sucursalDto">Datos de la sucursal a crear.</param>
        /// <returns>La nueva sucursal creada.</returns>
        public SucursalDTO CreateSucursal(SucursalDTO sucursalDto)
        {
            if (sucursalDto == null)
            {
                throw new ArgumentNullException(nameof(sucursalDto));
            }

            _context.Sucursales.Add(sucursalDto);
            _context.SaveChanges();

            return sucursalDto;
        }

        /// <summary>
        /// Elimina una sucursal por su ID.
        /// </summary>
        /// <param name="id">ID de la sucursal a eliminar.</param>
        /// <returns>La sucursal eliminada.</returns>
        public SucursalDTO DeleteSucursal(int id)
        {
            var sucursal = _context.Sucursales.Find(id);

            if (sucursal == null)
            {
                throw new Exception("La sucursal no existe.");
            }

            _context.Sucursales.Remove(sucursal);
            _context.SaveChanges();

            return sucursal;
        }

        /// <summary>
        /// Obtiene todas las sucursales.
        /// </summary>
        /// <returns>Lista de sucursales.</returns>
        public IEnumerable<SucursalDTO> GetAllSucursales()
        {
            return _context.Sucursales;
        }

        /// <summary>
        /// Obtiene una sucursal por su ID.
        /// </summary>
        /// <param name="id">ID de la sucursal.</param>
        /// <returns>La sucursal correspondiente al ID.</returns>
        public SucursalDTO GetSucursalById(int id)
        {
            return _context.Sucursales.Find(id);
        }

        /// <summary>
        /// Actualiza una sucursal existente.
        /// </summary>
        /// <param name="id">ID de la sucursal a actualizar.</param>
        /// <param name="sucursalDto">Datos actualizados de la sucursal.</param>
        /// <returns>La sucursal actualizada.</returns>
        public SucursalDTO UpdateSucursal(int id, SucursalDTO sucursalDto)
        {
            if (sucursalDto == null)
            {
                throw new ArgumentNullException(nameof(sucursalDto));
            }

            var existingSucursal = _context.Sucursales.Find(id);

            if (existingSucursal == null)
            {
                throw new Exception("La sucursal no existe.");
            }

            // Actualiza los campos de la sucursal con los nuevos valores
            existingSucursal.Codigo = sucursalDto.Codigo;
            existingSucursal.Descripcion = sucursalDto.Descripcion;
            existingSucursal.Direccion = sucursalDto.Direccion;
            existingSucursal.Identificacion = sucursalDto.Identificacion;
            existingSucursal.FechaCreacion = sucursalDto.FechaCreacion;
            existingSucursal.MonedaID = sucursalDto.MonedaID;

            _context.SaveChanges();

            return existingSucursal;
        }
    }
}
