namespace SGP.Core.Domain.Entities
{
    public class Amistad
    {
        public int IdAmistad { get; set; }
        public int IdUsuario { get; set; }
        public int IdAmigo { get; set; }

        //Navigation property:
        public Usuario? Usuario { get; set; }
        public Usuario? Amigo { get; set; }
    }
}
