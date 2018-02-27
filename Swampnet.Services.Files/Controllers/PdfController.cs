using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swampnet.Services.Files.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Files.Controllers
{
	[Route("pdf")]
	public class PdfController : Controller
	{
		private readonly IConverter _converter;

		public PdfController(IConverter converter)
		{
			_converter = converter;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreatePdfOptions options)
		{
			try
			{
				Log.Debug("{controller} post", GetType().Name);

				await Task.CompletedTask;

				if (options == null)
				{
					throw new ArgumentNullException("options");
				}
				if (string.IsNullOrEmpty(options.Html))
				{
					throw new ArgumentNullException("html");
				}

				var pdfBytes = BuildPdf(options.Html);

				return File(pdfBytes, "application/pdf");
			}
			catch (Exception ex)
			{
				ex.Data.Add("html", options?.Html);
				Log.Error(ex, ex.Message);

				return this.ServerError(ex);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Get()
		{
			Log.Debug("{controller} Get", GetType().Name);

			await Task.CompletedTask;

			var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
			var wkHtmlToPdfPath = Path.Combine(AppContext.BaseDirectory, $"libs\\wkhtmltox\\{architectureFolder}\\libwkhtmltox");


			return Ok(new CreatePdfOptions()
			{
				Html = "<html><h1>Hello, world!</h1><p>doo be do be dooo</p><img src=\"https://news.nationalgeographic.com/content/dam/news/2016/10/08/drill-monkey-waq/drill-monkey-01.adapt.1190.1.jpg\"/></html>",
				Hack_LibLocation = wkHtmlToPdfPath
			});
		}


		private byte[] BuildPdf(string html)
		{
			byte[] rs = null;

			var sw = Stopwatch.StartNew();

			rs = _converter.Convert(new HtmlToPdfDocument()
			{
				Objects =
				{
					new ObjectSettings
					{
						HtmlContent = html
					}
				}
			});

			Log.Information("Built pdf in {time:0.00}s", sw.Elapsed.TotalMilliseconds);

			return rs;
		}
	}
}
