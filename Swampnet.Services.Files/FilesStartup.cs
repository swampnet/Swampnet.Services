using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Swampnet.Services.Files;
using System.IO;
using Serilog;
using Swampnet.Services.Files.Interfaces;
using Swampnet.Services.Files.Services;

namespace Swampnet.Services
{
    public static class FilesStartup
    {
		public static void AddFilesApi(this IServiceCollection services)
		{
			services.AddSingleton<IConverter>(x => new SynchronizedConverter(new PdfTools()));
			services.AddSingleton<IImagesRepository, ImagesRepository>();

			var wkHtmlToPdfContext = new CustomAssemblyLoadContext();
			var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
			var wkHtmlToPdfPath = Path.Combine(AppContext.BaseDirectory, $"libs\\wkhtmltox\\{architectureFolder}\\libwkhtmltox");

			wkHtmlToPdfContext.LoadUnmanagedLibrary(wkHtmlToPdfPath);
		}
	}
}
