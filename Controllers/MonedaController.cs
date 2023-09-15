using Microsoft.AspNetCore.Mvc;
using Quala.Interfaces;
using Quala.Models;
using System;

namespace Quala.Controllers
{
    /// <summary>
    /// Controlador para administrar operaciones relacionadas con monedas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaRepository _monedaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MonedaController"/>.
        /// </summary>
        /// <param name="monedaRepository">Repositorio de monedas.</param>
        public MonedaController(IMonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository ?? throw new ArgumentNullException(nameof(monedaRepository));
        }

        /// <summary>
        /// Obtiene todas las monedas.
        /// </summary>
        /// <returns>Una lista de todas las monedas.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var monedas = _monedaRepository.GetAll();
            return Ok(monedas);
        }

        /// <summary>
        /// Obtiene una moneda por su ID.
        /// </summary>
        /// <param name="id">ID de la moneda.</param>
        /// <returns>La moneda con el ID especificado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var moneda = _monedaRepository.GetById(id);
            if (moneda == null)
            {
                return NotFound();
            }
            return Ok(moneda);
        }

        /// <summary>
        /// Crea una nueva moneda.
        /// </summary>
        /// <param name="moneda">Datos de la moneda a crear.</param>
        /// <returns>La moneda creada.</returns>
        [HttpPost]
        public IActionResult Create(MonedaDTO moneda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdMoneda = _monedaRepository.Create(moneda);
            return CreatedAtAction(nameof(GetById), new { id = createdMoneda.ID }, createdMoneda);
        }
    }
}
