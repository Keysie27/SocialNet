using System.ComponentModel.DataAnnotations;

namespace SGP.Core.Application.ViewModels.Comentarios
{
    public class SaveComentarioViewModel
    {
        public int IdComentario { get; set; }

        [Required(ErrorMessage = "Ingrese el contenido del Comentario.")]
        public string? Contenido { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
    }
}
