namespace SGP.Core.Domain.Entities
{
    public class Publicacion
    {
        public int IdPublicacion { get; set; }
        public string Contenido { get; set; }
        public string? FotoUrl { get; set; }
        public DateTime? FechaHora { get; set; }
        public int IdUsuario { get; set; }

        //Navigation property:
        public Usuario? Usuario { get; set;}
        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
