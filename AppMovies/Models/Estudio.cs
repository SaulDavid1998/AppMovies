using System.ComponentModel.DataAnnotations;

namespace AppMovies.Models
{
    public class Estudio
    {
        [Key]
        public int EstudioID{ get; set; }
        [Required]
        public string? Nombre { get; set; }

    }
}
