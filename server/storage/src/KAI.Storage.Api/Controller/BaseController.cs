using KAI.Storage.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace KAI.Storage.Api.Controller
{
	[ApiController]
	[Route("base")]
	public class BaseController : ControllerBase
	{
		private readonly IHttpClientFactory _clientFactory;

		public BaseController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		[HttpPost]
		public ActionResult<FileExtension> Test([FromBody] FileExtension fileExtension)
		{
			var httpClient = _clientFactory.CreateClient();
			return Ok(fileExtension);
		}
	}
}
