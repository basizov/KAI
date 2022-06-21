using KAI.Storage.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace KAI.Storage.Api.Controller
{
	[ApiController]
	[Route("base")]
	public class BaseController : ControllerBase
	{
		[HttpPost]
		public ActionResult<FileExtension> Test([FromBody] FileExtension fileExtension)
		{
			return Ok(fileExtension);
		}
	}
}
