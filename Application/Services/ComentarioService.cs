using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.ViewModels.Comentarios;

namespace SGP.Core.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository repository)
        {
            _comentarioRepository = repository;
        }

        public async Task<ComentarioViewModel> Add(ComentarioViewModel vm)
        {
            Comentario comentario = new()
            {
                Contenido = vm.Contenido,
                FechaHora = DateTime.Now,
                IdUsuario = vm.IdUsuario,
                IdPublicacion = vm.IdPublicacion,
            };

            comentario = await _comentarioRepository.AddAsync(comentario);

            ComentarioViewModel comentarioVm = new()
            {
                IdComentario = comentario.IdComentario,
                Contenido = comentario.Contenido,
                FechaHora = comentario.FechaHora,
                IdPublicacion = comentario.IdPublicacion,
                IdUsuario = comentario.IdUsuario,
            };

            return comentarioVm;
        }
        
        public async Task Update(ComentarioViewModel vm)
        {
            Comentario comentario = await _comentarioRepository.GetByIdAsync(vm.IdComentario);
            comentario.IdComentario = vm.IdComentario;
            comentario.Contenido = vm.Contenido;
            comentario.FechaHora = vm.FechaHora;
            comentario.IdPublicacion = vm.IdPublicacion;
            comentario.IdUsuario = vm.IdUsuario;

            await _comentarioRepository.UpdateAsync(comentario);
        }
        
        public async Task Delete(int IdComentario)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(IdComentario);

            await _comentarioRepository.DeleteAsync(comentario);
        }

        public async Task<List<ComentarioViewModel>> GetAllViewModels()
        {
            var comentarios = await _comentarioRepository.GetAllWithIncludeAsync(new List<string> { "Usuario", "Publicacion" });
            comentarios = comentarios.OrderByDescending(comentario => comentario.FechaHora).ToList();

            return comentarios.Select(comentario => new ComentarioViewModel
            {
                IdComentario = comentario.IdComentario,
                Contenido = comentario.Contenido,
                FechaHora = comentario.FechaHora,
                IdUsuario = comentario.IdUsuario,
                Usuario = comentario.Usuario,
                IdPublicacion = comentario.IdPublicacion,
                Publicacion = comentario.Publicacion,
            }).ToList();
        }

        public async Task<ComentarioViewModel> GetViewModelById(int IdComentario)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(IdComentario);

            ComentarioViewModel vm = new()
            {
                IdComentario = comentario.IdPublicacion,
                Contenido = comentario.Contenido,
                FechaHora = comentario.FechaHora,
                IdUsuario = comentario.IdUsuario,
                IdPublicacion = comentario.IdPublicacion,
            };

            return vm;
        }
    }
}
