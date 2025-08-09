using CRUD_Game_List.Business;
using CRUD_Game_List.DTOs;
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

		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			var category = _categoryBusiness.FindCategoryById(id);
			if (category == null) return NotFound();

			return Ok(category);
		}

		[HttpPost]
		public IActionResult Post([FromBody] CategoryCreateDto categoryDto)
		{
			if (string.IsNullOrEmpty(categoryDto.Name)) return BadRequest("Must provide a category name.");
			var cat = _categoryBusiness.AddCategory(categoryDto.Name);
			return Ok(cat);
		}

	}
}
