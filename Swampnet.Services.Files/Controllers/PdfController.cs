using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Files.Controllers
{
	[Route("pdf")]
	public class PdfController : Controller
	{
		static IConverter _pdfConverter = new SynchronizedConverter(new PdfTools());


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreatePdfOptions options)
		{
			await Task.CompletedTask;

			var pdfBytes = BuildPdf(options.Html);

			return File(pdfBytes, "application/pdf");
		}


		[HttpGet]
		public async Task<IActionResult> Get()
		{
			await Task.CompletedTask;

			return Ok(new CreatePdfOptions() { Html = "<html><h1>Hello, world!</h1><p>doo be do be dooo</p><img src=\"https://news.nationalgeographic.com/content/dam/news/2016/10/08/drill-monkey-waq/drill-monkey-01.adapt.1190.1.jpg\"/></html>" });
		}


		private byte[] BuildPdf(string html)
		{
			byte[] rs = null;

			var sw = Stopwatch.StartNew();

			rs = _pdfConverter.Convert(new HtmlToPdfDocument()
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


	public class CreatePdfOptions
	{
		public string Html { get; set; }
	}
}
