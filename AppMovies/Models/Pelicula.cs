using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMovies.Models
{
    public class Pelicula
    {
        [Key]
        public int PeliculaId { get; set; }

        [Required(ErrorMessage ="El campo del titulo es obligatorio")]
        public string Titulo { get; set; }=string.Empty;

        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El campo del año es obligatorio")]
        [Range(1900,2025,ErrorMessage ="El rango para la pelicula es entre 1900 y 2025")]
        public int Año { get; set; }

        [Required(ErrorMessage ="Se tiene que establecer un director a la pelicula")]
        public int? IdDirector { get; set; }

        [ForeignKey("IdDirector")]
        [ValidateNever]
        public Director Director { get; set; } = null!;

        public int? IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        [ValidateNever]
        public Estudio Estudio { get; set; } = null!;
    }
}
