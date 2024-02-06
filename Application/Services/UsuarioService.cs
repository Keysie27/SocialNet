using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;
using SGP.Core.Application.ViewModels.Usuarios;
using SGP.Core.Application.Interfaces.Services;
using System.Numerics;
using System.Xml.Linq;

namespace SGP.Core.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<UsuarioViewModel> Login(LoginViewModel vm)
        {
            Usuario usuario = await _usuarioRepository.LoginAsync(vm);

            if (usuario == null)
            {
                return null;
            }

            UsuarioViewModel userVm = new()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                FotoUrl = usuario.FotoUrl,
                Correo = usuario.Correo,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Activo = usuario.Activo,
            };

            return userVm;
        }

        public async Task<SaveUsuarioViewModel> Add(SaveUsuarioViewModel vm)
        {
            Usuario usuario = new()
            {
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Telefono = vm.Telefono,
                FotoUrl = vm.FotoUrl,
                Correo = vm.Correo,
                NombreUsuario = vm.NombreUsuario,
                Contraseña = vm.Contraseña,
                Activo = vm.Activo,
            };
            
            usuario = await _usuarioRepository.AddAsync(usuario);

            SaveUsuarioViewModel usuarioVm = new()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = vm.Telefono,
                FotoUrl = vm.FotoUrl,
                Correo = usuario.Correo,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Activo = vm.Activo,
            };

            return usuarioVm;
        }
        
        public async Task Update(SaveUsuarioViewModel vm)
        {
            Usuario usuario = await _usuarioRepository.GetByIdAsync(vm.IdUsuario);
            usuario.IdUsuario = vm.IdUsuario;
            usuario.Nombre = vm.Nombre;
            usuario.Apellido = vm.Apellido;
            usuario.Telefono = vm.Telefono;
            usuario.FotoUrl = vm.FotoUrl;
            usuario.Correo = vm.Correo;
            usuario.NombreUsuario = vm.NombreUsuario;
            usuario.Contraseña = vm.Contraseña;
            usuario.Activo = vm.Activo;
            
            await _usuarioRepository.UpdateAsync(usuario);
        }
        
        public async Task Delete(int IdUsuario)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(IdUsuario);

            await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<List<UsuarioViewModel>> GetAllViewModels()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            return usuarios.Select(usuario => new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                FotoUrl = usuario.FotoUrl,
                Correo = usuario.Correo,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Activo = usuario.Activo,
            }).ToList();
        }     
        
        public async Task<SaveUsuarioViewModel> GetViewModelById(int IdUsuario)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(IdUsuario);

            SaveUsuarioViewModel vm = new()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                FotoUrl = usuario.FotoUrl,
                Correo = usuario.Correo,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Activo = usuario.Activo,
            };

            return vm;
        }
    }
}
