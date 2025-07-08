using System.ComponentModel.DataAnnotations;

namespace F1ApiBase.Models
{
    /// Representa un piloto de Fórmula 1.
    public class Piloto
    {

        /// Identificador único del piloto.
        public int Id { get; set; }

        /// Nombre completo del piloto.
        [Required(ErrorMessage = "El nombre del piloto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        /// Nacionalidad del piloto.
        [Required(ErrorMessage = "La nacionalidad del piloto es obligatoria.")]
        [StringLength(50, ErrorMessage = "La nacionalidad no puede exceder los 50 caracteres.")]
        public string Nacionalidad { get; set; } = string.Empty;

        /// Fecha de nacimiento del piloto.
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        /// ID del circuito favorito o asociado al piloto (relación 1:N).
 
        public int CircuitoId { get; set; }

        /// Puntos obtenidos por el piloto en el circuito asociado.

        [Range(0, int.MaxValue, ErrorMessage = "Los puntos deben ser un valor no negativo.")]
        public int PuntosEnCircuito { get; set; }

        /// Posición obtenida por el piloto en el circuito asociado.
        [Range(1, 20, ErrorMessage = "La posición debe estar entre 1 y 20.")]
        public int PosicionEnCircuito { get; set; }

        /// Tiempo registrado por el piloto en el circuito asociado (ej. "1:20.500").
        [StringLength(20, ErrorMessage = "El tiempo no puede exceder los 20 caracteres.")]
        public string TiempoEnCircuito { get; set; } = string.Empty;
    }
}
