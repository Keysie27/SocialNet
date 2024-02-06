using Microsoft.EntityFrameworkCore;
using SGP.Core.Domain.Entities;

namespace SGP.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Amistad> Amistades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region Tables
                modelBuilder.Entity<Usuario>().ToTable("Usuarios");
                modelBuilder.Entity<Publicacion>().ToTable("Publicaciones");
                modelBuilder.Entity<Comentario>().ToTable("Comentarios");
                modelBuilder.Entity<Amistad>().ToTable("Amistades");
            #endregion

            #region "Primary Keys"
                modelBuilder.Entity<Usuario>().HasKey(usuario => usuario.IdUsuario);
                modelBuilder.Entity<Publicacion>().HasKey(publicacion => publicacion.IdPublicacion);
                modelBuilder.Entity<Comentario>().HasKey(comentario => comentario.IdComentario);
                modelBuilder.Entity<Amistad>().HasKey(amistad => amistad.IdAmistad);
            #endregion

            #region relationships
                #region Usuario/Publicacion
                    modelBuilder.Entity<Usuario>()
                        .HasMany<Publicacion>(usuario => usuario.Publicaciones)
                        .WithOne(publicacion => publicacion.Usuario)
                        .HasForeignKey(publicacion => publicacion.IdUsuario)
                        .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Usuario/Comentario
            modelBuilder.Entity<Comentario>()
                        .HasOne(comentario => comentario.Usuario)
                        .WithMany(usuario => usuario.Comentarios)
                        .HasForeignKey(comentario => comentario.IdUsuario)
                        .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Publicacion/Comentario
            modelBuilder.Entity<Comentario>()
                .HasOne(comentario => comentario.Publicacion)
                .WithMany(publicacion => publicacion.Comentarios)
                .HasForeignKey(comentario => comentario.IdPublicacion)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Amistad/Usuario
            modelBuilder.Entity<Amistad>()
               .HasOne(amistad => amistad.Usuario)
               .WithMany(usuario => usuario.Amistades)
               .HasForeignKey(amistad => amistad.IdUsuario)
               .OnDelete(DeleteBehavior.Cascade);
;

            modelBuilder.Entity<Amistad>()
                .HasOne(amistad => amistad.Amigo)
                .WithMany()
                .HasForeignKey(amistad => amistad.IdAmigo)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #endregion

            #region "Propertys configurations"
            #region Usuario
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Nombre)
                        .IsRequired()
                        .HasMaxLength(50);
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.Apellido)
                        .IsRequired()
                        .HasMaxLength(100);
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.Telefono)
                        .IsRequired()
                        .HasMaxLength(20);
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.FotoUrl)
                        .IsRequired(false);
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.NombreUsuario)
                        .IsRequired()
                        .HasMaxLength(30);
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.Correo)
                        .IsRequired();
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.Contraseña)
                        .IsRequired();
                    modelBuilder.Entity<Usuario>().Property(usuario => usuario.Activo)
                        .IsRequired();


                    modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.NombreUsuario)
                        .IsUnique();
                    modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Correo)
                        .IsUnique();
                #endregion

                #region Publicacion
                    modelBuilder.Entity<Publicacion>().Property(publicacion => publicacion.Contenido)
                        .IsRequired();
                    modelBuilder.Entity<Publicacion>().Property(publicacion => publicacion.FotoUrl)
                        .IsRequired(false);
                    modelBuilder.Entity<Publicacion>().Property(publicacion => publicacion.FechaHora)
                        .IsRequired();
                #endregion
            
                #region Comentario
                    modelBuilder.Entity<Comentario>().Property(comentario => comentario.Contenido)
                        .IsRequired();
                    modelBuilder.Entity<Comentario>().Property(comentario => comentario.FechaHora)
                                .IsRequired();
            #endregion
            #endregion
        }
    }
}
