using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

			return Ok(new CreatePdfOptions() { Html = "<html></html>"});
		}


		private static byte[] BuildPdf(string html)
		{
			return _pdfConverter.Convert(new HtmlToPdfDocument()
			{
				Objects =
				{
					new ObjectSettings
					{
						HtmlContent = html
					}
				}
			});
		}
	}


	public class CreatePdfOptions
	{
		public string Html { get; set; }
	}
}
