using Microsoft.AspNetCore.Http;
using SGP.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SGP.Core.Application.ViewModels.Publicaciones
{
    public class SavePublicacionViewModel
    {
        public int IdPublicacion { get; set; }

        [Required(ErrorMessage = "Ingrese el contenido de la publicación.")]
        public string Contenido { get; set; }
        public DateTime FechaHora { get; set; }        
        public string? FotoUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        public int IdUsuario { get; set; }

        //Navigation property:
        public Usuario? Usuario { get; set; }
        public ICollection<Publicacion>? Publicaciones { get; set; }
    }
}
