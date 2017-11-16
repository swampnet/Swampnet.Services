using Microsoft.Extensions.DependencyInjection;
using Swampnet.Services.Images.Interfaces;
using Swampnet.Services.Images.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swampnet.Services
{
    public static class ImagesStartup
    {
        public static void AddImagesApi(this IServiceCollection services)
        {
            services.AddSingleton<IImagesRepository, ImagesRepository>();
        }
    }
}
