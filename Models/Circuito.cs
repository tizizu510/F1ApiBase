using System.ComponentModel.DataAnnotations;

namespace F1ApiBase.Models
{
    /// Representa un circuito de Fórmula 1.
    public class Circuito
    {
        /// Identificador único del circuito.
        public int Id { get; set; }

        /// Nombre del circuito.
        [Required(ErrorMessage = "El nombre del circuito es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        /// País donde se ubica el circuito.
 
        [Required(ErrorMessage = "El país del circuito es obligatorio.")]
        [StringLength(50, ErrorMessage = "El país no puede exceder los 50 caracteres.")]
        public string Pais { get; set; } = string.Empty;

        /// Longitud del circuito en kilómetros.
        [Range(0.1, 20.0, ErrorMessage = "La longitud debe ser un valor positivo y razonable.")]
        public double LongitudKm { get; set; }
    }
}
