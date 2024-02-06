namespace SGP.Core.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string? FotoUrl { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool? Activo { get; set; }

        //Navigation property:
        public ICollection<Publicacion>? Publicaciones { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Amistad>? Amistades { get; set; }
    }
}
