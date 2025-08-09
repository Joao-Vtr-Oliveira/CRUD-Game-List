using CRUD_Game_List.Business;
using CRUD_Game_List.DTOs;
using CRUD_Game_List.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

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
			var categories = _categoryBusiness.GetCategories();
			var dtos = categories.Select(c => new CategoryDto(c.Id, c.Name));
			return Ok(dtos);
		}

		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			var category = _categoryBusiness.FindCategoryById(id);
			if (category == null) return NotFound();

			return Ok(new CategoryDto(category.Id, category.Name));
		}

		[HttpPost]
		public IActionResult Post([FromBody] CategoryCreateDto categoryDto)
		{
			if (string.IsNullOrEmpty(categoryDto.Name)) return BadRequest("Must provide a category name.");
			var created = _categoryBusiness.AddCategory(categoryDto.Name);
			var dto = new CategoryDto(created.Id, created.Name);
			return CreatedAtAction(nameof(Get), new { id = created.Id }, dto);
		}

	}
}
