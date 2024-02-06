﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SGP.Core.Application.ViewModels.Usuarios
{
    public class SaveUsuarioViewModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese su Nombre.")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese su Apellido.")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "Ingrese su número de Teléfono.")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Ingrese su Correo Electrónico.")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese su Nombre de Usuario.")]
        [DataType(DataType.Text)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese su Contraseña de usuario.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Compare(nameof(Contraseña), ErrorMessage = "Las Contraseñas no coinciden.")]
        [Required(ErrorMessage = "Escribe tu contraseña para confirmar.")]
        [DataType(DataType.Password)]
        public string ConfirmarContraseña { get; set; }

        public bool? Activo { get; set; }
        public string? FotoUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
