using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.ViewModels.Amistades;

namespace SGP.Core.Application.Services
{
    public class AmistadService : IAmistadService
    {
        private readonly IAmistadRepository _amistadRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AmistadService(IAmistadRepository amistadRepository, IUsuarioRepository usuarioRepository)
        {
            _amistadRepository = amistadRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task Add(AmistadViewModel vm)
        {
            Usuario amigo = await _usuarioRepository.GetByUsernameAsync(vm.UsuarioAmigo);

            Amistad amistad = new()
            {
                IdUsuario = (int)vm.IdUsuario,
                IdAmigo = amigo.IdUsuario,
            };

            await _amistadRepository.AddAsync(amistad);
        }
        
        public async Task Update(AmistadViewModel vm)
        {
            Amistad amistad = await _amistadRepository.GetByIdAsync(vm.Amistad.IdAmistad);
            amistad.IdAmistad = vm.Amistad.IdAmistad;
            amistad.IdUsuario = vm.Amistad.IdUsuario;
            amistad.IdAmigo = vm.Amistad.IdAmigo;

            await _amistadRepository.UpdateAsync(amistad);
        }
        
        public async Task Delete(int IdAmistad)
        {
            var amistad = await _amistadRepository.GetByIdAsync(IdAmistad);

            await _amistadRepository.DeleteAsync(amistad);
        }

        public async Task<List<Amistad>> GetAllViewModels()
        {
            var amistades = await _amistadRepository.GetAllWithIncludeAsync(new List<string> { "Usuario", "Publicacion" });

            return amistades.Select(amistad => new Amistad
            {
                IdAmistad = amistad.IdAmistad,
                IdUsuario = amistad.IdUsuario,
                Usuario = amistad.Usuario,
                IdAmigo = amistad.IdAmigo,
                Amigo = amistad.Amigo,
            }).ToList();
        }

        public async Task<Amistad> GetViewModelById(int IdAmistad)
        {
            var amistad = await _amistadRepository.GetByIdAsync(IdAmistad);

            Amistad vm = new()
            {
                IdAmistad = amistad.IdAmistad,
                IdUsuario = amistad.IdUsuario,
                IdAmigo = amistad.IdAmigo,
            };

            return vm;
        }

        Task<AmistadViewModel> IGenericService<AmistadViewModel, AmistadViewModel>.Add(AmistadViewModel vm)
        {
            throw new NotImplementedException();
        }

        Task<List<AmistadViewModel>> IGenericService<AmistadViewModel, AmistadViewModel>.GetAllViewModels()
        {
            throw new NotImplementedException();
        }

        Task<AmistadViewModel> IGenericService<AmistadViewModel, AmistadViewModel>.GetViewModelById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
