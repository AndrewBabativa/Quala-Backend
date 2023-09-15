using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quala.Models
{
    /// <summary>
    /// Representa una sucursal.
    /// </summary>
    public class SucursalDTO
    {
        /// <summary>
        /// Identificador único de la sucursal.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Código de la sucursal.
        /// </summary>
        [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
        public int Codigo { get; set; }

        /// <summary>
        /// Descripción de la sucursal.
        /// </summary>
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        [MaxLength(250, ErrorMessage = "La Descripcion no puede tener más de 250 caracteres.")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Dirección de la sucursal.
        /// </summary>
        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        [MaxLength(250, ErrorMessage = "La Direccion no puede tener más de 250 caracteres.")]
        public string Direccion { get; set; }

        /// <summary>
        /// Identificación de la sucursal.
        /// </summary>
        [Required(ErrorMessage = "El campo Identificacion es obligatorio.")]
        [MaxLength(50, ErrorMessage = "La Identificacion no puede tener más de 50 caracteres.")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Fecha de creación de la sucursal.
        /// </summary>
        [Required(ErrorMessage = "El campo FechaCreacion es obligatorio.")]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha de creación debe estar entre 1900 y 2100.")]
        [CurrentDate(ErrorMessage = "La fecha de creación no puede ser menor que la fecha actual.")]
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// ID de la moneda asociada a la sucursal.
        /// </summary>
        public int MonedaID { get; set; }

    }

    /// <summary>
    /// Atributo de validación personalizado para verificar si una fecha es igual o posterior a la fecha actual.
    /// </summary>
    public class CurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime fecha)
            {
                DateTime fechaActual = DateTime.Now;

                if (fecha >= fechaActual)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
