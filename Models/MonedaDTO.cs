using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quala.Models
{
    /// <summary>
    /// Representa una entidad de moneda.
    /// </summary>
    public class MonedaDTO
    {
        /// <summary>
        /// Identificador único de la moneda.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Nombre de la moneda.
        /// </summary>
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Símbolo de la moneda.
        /// </summary>
        [Required(ErrorMessage = "El campo Simbolo es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El Simbolo no puede tener más de 10 caracteres.")]
        public string Simbolo { get; set; }
    }
}
