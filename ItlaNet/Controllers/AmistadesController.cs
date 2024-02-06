using Microsoft.AspNetCore.Mvc;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.ViewModels.Amistades;
using SGP.Core.Application.ViewModels.Comentarios;
using SGP.Core.Application.ViewModels.Publicaciones;
using SGP.WebApp.Middlewares;

namespace SGP.Core.Application.Controllers
{
    public class AmistadesController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;
        private readonly IComentarioService _comentarioService;
        private readonly IAmistadService _amistadService;
        private readonly IPublicacionService _publicacionService;
        private readonly IUsuarioService _usuarioService;

        public AmistadesController(IPublicacionService publicacionService, IComentarioService comentarioService, IAmistadService amistadService, ValidateUserSession validateUserSession, IUsuarioService usuarioService)
        {
            _validateUserSession = validateUserSession;
            _comentarioService = comentarioService;
            _amistadService = amistadService;
            _publicacionService = publicacionService;
            _usuarioService=usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            AmistadViewModel vm = new()
            {
                Publicaciones = await _publicacionService.GetAllViewModels(),
                Comentarios = await _comentarioService.GetAllViewModels(),
                Usuarios = await _usuarioService.GetAllViewModels(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarComentario(AmistadViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            //if (!ModelState.IsValid)
            //{
            //    vm.Publicaciones = await _publicacionService.GetAllViewModels();
            //    vm.Comentarios = await _comentarioService.GetAllViewModels();

            //    return View("Index", vm);
            //}
            else
            {
                //SavePublicacionViewModel publicacionVm = await _publicacionService.Add(vm);

                //if (publicacionVm != null && publicacionVm.IdPublicacion != 0)
                //{
                //    publicacionVm.FotoUrl = UploadImage(vm.File, publicacionVm.IdPublicacion);
                //    await _publicacionService.Update(publicacionVm);
                //}
                ComentarioViewModel vmComentario = vm.Comentario;
                 
                await _comentarioService.Add(vmComentario);

                return RedirectToRoute(new { controller = "Amistades", action = "Index" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAmistad(AmistadViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            //if (!ModelState.IsValid)
            //{
            //    vm.Publicaciones = await _publicacionService.GetAllViewModels();
            //    vm.Comentarios = await _comentarioService.GetAllViewModels();

            //    return View("Index", vm);
            //}
            else
            {
                //SavePublicacionViewModel publicacionVm = await _publicacionService.Add(vm);

                //if (publicacionVm != null && publicacionVm.IdPublicacion != 0)
                //{
                //    publicacionVm.FotoUrl = UploadImage(vm.File, publicacionVm.IdPublicacion);
                //    await _publicacionService.Update(publicacionVm);
                //}

                await _amistadService.Add(vm);

                return RedirectToRoute(new { controller = "Amistades", action = "Index" });
            }
        }
    }
}