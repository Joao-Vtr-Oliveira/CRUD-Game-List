using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Game_List.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello world!");
		}
	}
}
