using CRUD_Game_List.Business;
using CRUD_Game_List.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Game_List.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private ICategoryBusiness _categoryBusiness;

		public CategoryController(ICategoryBusiness categoryBusiness)
		{
			_categoryBusiness = categoryBusiness;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_categoryBusiness.GetCategories());
		}

		[HttpPost]
		public IActionResult Post([FromBody] Category category)
		{
			if (category == null) return BadRequest("Must provide a category.");
			var cat = _categoryBusiness.AddCategory(category.Name);
			return Ok(cat);
		}
	}
}
