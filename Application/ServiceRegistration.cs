using Microsoft.Extensions.DependencyInjection;
using SGP.Core.Application.Interfaces.Services;
using SGP.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services                
                services.AddTransient<IUsuarioService, UsuarioService>();
                services.AddTransient<IPublicacionService, PublicacionService>();
                services.AddTransient<IComentarioService, ComentarioService>();
                services.AddTransient<IAmistadService, AmistadService>();
            #endregion
        }
    }
}
