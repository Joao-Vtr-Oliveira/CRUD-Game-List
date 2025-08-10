using CRUD_Game_List.Business;
using CRUD_Game_List.Business.Implementations;
using CRUD_Game_List.DTOs;
using CRUD_Game_List.Model;
using Microsoft.AspNetCore.Mvc;
using static CRUD_Game_List.DTOs.GameDtos;

namespace CRUD_Game_List.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
		private IGameBusiness _gameBusiness;

		public GameController(IGameBusiness gameBusiness)
		{
			_gameBusiness = gameBusiness;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var games = _gameBusiness.GetGames();
			return Ok(games);
		}

		[HttpPost]
		public IActionResult Post([FromBody] GameCreateDto gameCreateDto)
		{
			// TODO: Check if the category exists in business

			var game = new Game
			{
				Title = gameCreateDto.Title,
				CategoryID = gameCreateDto.CategoryId,
				Platform = gameCreateDto.Platform,
				Year = gameCreateDto.Year
			};

			var created = _gameBusiness.AddGame(game);

			var dto = new GameDto(
					created.Id,
					created.Title,
					created.Category.Name,
					created.Platform,
					created.Year
			);

			return CreatedAtAction(nameof(GetById), new { id = created.Id }, dto);
		}

		[HttpGet("{id:long}")]
		public ActionResult<GameDto> GetById(long id)
		{
			var g = _gameBusiness.FindGameById(id);
			return Ok(new GameDto(g.Id, g.Title, g.Category.Name, g.Platform, g.Year));
		}

		// TODO: Implement put and Delete
		[HttpPut("{id:long}")]
		public ActionResult<GameUpdateDto> Put(long id, [FromBody] GameUpdateDto gameUpdateDto)
		{
			//var updated = _categoryBusiness.UpdateCategory();
			//var dto = new CategoryDto(updated.Id, updated.Name);
			return Ok("Placeholder");
		}


		[HttpDelete("{id:long}")]
		public ActionResult Delete(long id)
		{
			//_categoryBusiness.DeleteCategory(id);
			return NoContent();
		}
	}
}
