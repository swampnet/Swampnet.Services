using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Swampnet.Services
{
    public static class ControllerExtensions
    {
		public static IActionResult ServerError(this Controller controller, Exception ex)
		{
			return controller.StatusCode((int)HttpStatusCode.InternalServerError, ex);
		}
	}
}
