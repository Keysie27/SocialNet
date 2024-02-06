using Microsoft.AspNetCore.Mvc;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.ViewModels;
using SGP.Core.Application.ViewModels.Usuarios;
using SGP.WebApp.Middlewares;

namespace SGP.Core.Application.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _usuarioService.GetAllViewModels());
        }

        public IActionResult CreateUsuario()
        {
            return View("SaveUsuario", new SaveUsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(SaveUsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveUsuario", vm);
            }
            else
            {
                SaveUsuarioViewModel usuarioVm = await _usuarioService.Add(vm);

                if (usuarioVm != null && usuarioVm.IdUsuario != 0)
                {
                    usuarioVm.FotoUrl = UploadImage(vm.File, usuarioVm.IdUsuario);
                    await _usuarioService.Update(usuarioVm);
                }

                //await _usuarioService.Add(vm);
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
        }

        public async Task<IActionResult> EditUsuario(int IdUsuario)
        {   
            return View("SaveUsuario", await _usuarioService.GetViewModelById(IdUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> EditUsuario(SaveUsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveUsuario", vm);
            }
            else
            {
                await _usuarioService.Update(vm);
                return RedirectToRoute(new { controller = "Usuarios", action = "Index" });
            }
        }

        public async Task<IActionResult> DeleteUsuario(int IdUsuario)
        {
            return View("DeleteUsuario", await _usuarioService.GetViewModelById(IdUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsuarioPost(int IdUsuario)
        {
            await _usuarioService.Delete(IdUsuario);

            return RedirectToRoute(new { controller = "Usuarios", action = "Index" });
        }

        private string UploadImage(IFormFile file, int IdUsuario, string imageUrl = "")
        {
            // Obtener la ruta del directorio
            string basePath = $"/images/Usuarios/{IdUsuario}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // Crear el diretorio de la foto si no existe
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Generar el nombre que tendrá la imagen
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new (file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"{basePath}/{fileName}";
        }
    }
}
