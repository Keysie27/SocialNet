using SGP.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SGP.Core.Application.ViewModels.Comentarios
{
    public class ComentarioViewModel
    {
        public int IdComentario { get; set; }

        [Required(ErrorMessage = "Ingrese el contenido del Comentario.")]
        public string Contenido { get; set; }
        public DateTime? FechaHora { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }

        //Navigation property:
        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }
    }
}
