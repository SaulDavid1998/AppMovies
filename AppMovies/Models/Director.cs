using System.ComponentModel.DataAnnotations;

namespace AppMovies.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }

        [Required(ErrorMessage ="El campo del nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage ="Se tiene que establecer una fecha de nacimiento")]
        public DateTime? FechaNac { get; set; }

    }
}
