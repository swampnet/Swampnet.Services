using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swampnet.Services
{
    public static class FilesStartup
    {
		public static void AddFilesApi(this IServiceCollection services)
		{
			services.AddSingleton<IConverter>(x => new SynchronizedConverter(new PdfTools()));
			//services.AddSingleton<IImagesRepository, ImagesRepository>();
		}
	}
}
