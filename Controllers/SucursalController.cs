using Microsoft.AspNetCore.Mvc;
using Quala.Interfaces;
using Quala.Models;

/// <summary>
/// Controlador para la gestión de sucursales.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SucursalController : ControllerBase
{
    private readonly ISucursalService _sucursalService;

    /// <summary>
    /// Constructor del controlador de sucursales.
    /// </summary>
    /// <param name="sucursalService">Servicio de sucursales.</param>
    public SucursalController(ISucursalService sucursalService)
    {
        _sucursalService = sucursalService;
    }

    /// <summary>
    /// Obtiene todas las sucursales.
    /// </summary>
    /// <returns>Lista de sucursales.</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var sucursales = _sucursalService.GetAllSucursales();
        return Ok(sucursales);
    }

    /// <summary>
    /// Obtiene una sucursal por su ID.
    /// </summary>
    /// <param name="id">ID de la sucursal.</param>
    /// <returns>La sucursal correspondiente al ID.</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var sucursal = _sucursalService.GetSucursalById(id);
        if (sucursal == null)
            return NotFound();

        return Ok(sucursal);
    }

    /// <summary>
    /// Crea una nueva sucursal.
    /// </summary>
    /// <param name="sucursalDto">Datos de la sucursal a crear.</param>
    /// <returns>La nueva sucursal creada.</returns>
    [HttpPost]
    public IActionResult Create([FromBody] SucursalDTO sucursalDto)
    {
        if (sucursalDto == null)
            return BadRequest();

        var newSucursal = _sucursalService.CreateSucursal(sucursalDto);
        return CreatedAtAction(nameof(GetById), new { id = newSucursal.Id }, newSucursal);
    }

    /// <summary>
    /// Actualiza una sucursal existente.
    /// </summary>
    /// <param name="id">ID de la sucursal a actualizar.</param>
    /// <param name="sucursalDto">Datos actualizados de la sucursal.</param>
    /// <returns>La sucursal actualizada.</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] SucursalDTO sucursalDto)
    {
        if (sucursalDto == null)
            return BadRequest();

        var updatedSucursal = _sucursalService.UpdateSucursal(id, sucursalDto);
        if (updatedSucursal == null)
            return NotFound();

        return Ok(updatedSucursal);
    }

    /// <summary>
    /// Elimina una sucursal por su ID.
    /// </summary>
    /// <param name="id">ID de la sucursal a eliminar.</param>
    /// <returns>La sucursal eliminada.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedSucursal = _sucursalService.DeleteSucursal(id);
        if (deletedSucursal == null)
            return NotFound();

        return Ok(deletedSucursal);
    }
}
