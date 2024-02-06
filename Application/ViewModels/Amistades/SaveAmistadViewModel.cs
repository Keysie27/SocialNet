using SGP.Core.Application.ViewModels.Comentarios;
using SGP.Core.Application.ViewModels.Publicaciones;
using SGP.Core.Domain.Entities;

namespace SGP.Core.Application.ViewModels.Amistades
{
    public class SaveAmistadViewModel
    {
        public int? IdUsuario { get; set; }
        public string? UsuarioAmigo { get; set; }

        public ComentarioViewModel? Comentario { get; set; }
        public Amistad? Amistad { get; set; }

        //Navigation property:
        public List<PublicacionViewModel>? Publicaciones { get; set; }
        public List<ComentarioViewModel>? Comentarios { get; set; }
        public List<Amistad>? Amistades { get; set; }
    }
}
