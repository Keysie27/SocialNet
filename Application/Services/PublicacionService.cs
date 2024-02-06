using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.ViewModels.Publicaciones;

namespace SGP.Core.Application.Services
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public PublicacionService(IPublicacionRepository repository)
        {
            _publicacionRepository = repository;
        }

        public async Task<PublicacionViewModel> Add(PublicacionViewModel vm)
        {
            Publicacion publicacion = new()
            {
                Contenido = vm.Contenido,
                FotoUrl = vm.FotoUrl,
                FechaHora = DateTime.Now,
                IdUsuario = vm.IdUsuario,
            };

            publicacion = await _publicacionRepository.AddAsync(publicacion);

            PublicacionViewModel publicacionVm = new()
            {
                IdPublicacion = publicacion.IdPublicacion,
                Contenido = publicacion.Contenido,
                FotoUrl = publicacion.FotoUrl,
                FechaHora = publicacion.FechaHora,
                IdUsuario = publicacion.IdUsuario,
            };

            return publicacionVm;
        }
        
        public async Task Update(PublicacionViewModel vm)
        {
            Publicacion publicacion = await _publicacionRepository.GetByIdAsync(vm.IdPublicacion);
            publicacion.IdPublicacion = vm.IdPublicacion;
            publicacion.Contenido = vm.Contenido;
            publicacion.FotoUrl = vm.FotoUrl;
            publicacion.FechaHora = vm.FechaHora;
            publicacion.IdUsuario = vm.IdUsuario;

            await _publicacionRepository.UpdateAsync(publicacion);
        }
        
        public async Task Delete(int IdPublicacion)
        {
            var publicacion = await _publicacionRepository.GetByIdAsync(IdPublicacion);

            await _publicacionRepository.DeleteAsync(publicacion);
        }

        public async Task<List<PublicacionViewModel>> GetAllViewModels()
        {
            var publicaciones = await _publicacionRepository.GetAllWithIncludeAsync(new List<string> { "Usuario" });
            publicaciones = publicaciones.OrderByDescending(publicacion => publicacion.FechaHora).ToList();

            return publicaciones.Select(publicacion => new PublicacionViewModel
            {
                IdPublicacion = publicacion.IdPublicacion,
                Contenido = publicacion.Contenido,
                FotoUrl = publicacion.FotoUrl,
                FechaHora = publicacion.FechaHora,
                IdUsuario = publicacion.IdUsuario,
                Usuario = publicacion.Usuario,
            }).ToList();
        }

        public async Task<PublicacionViewModel> GetViewModelById(int IdPublicacion)
        {
            var publicacion = await _publicacionRepository.GetByIdAsync(IdPublicacion);

            PublicacionViewModel vm = new()
            {
                IdPublicacion = publicacion.IdPublicacion,
                Contenido = publicacion.Contenido,
                FotoUrl = publicacion.FotoUrl,
                FechaHora = publicacion.FechaHora,
                IdUsuario = publicacion.IdUsuario,
            };

            return vm;
        }
    }
}
