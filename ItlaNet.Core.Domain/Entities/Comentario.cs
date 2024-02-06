namespace SGP.Core.Domain.Entities
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Contenido { get; set; }
        public DateTime? FechaHora { get; set; }

        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }

        //Navigation property:
        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }
    }
}
