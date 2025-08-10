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
			var dtos = games.Select(g => new GameDto(g.Id, g.Title, g.Category.Name, g.Platform, g.Year));
			return Ok(dtos);
		}

		[HttpPost]
		public IActionResult Post([FromBody] GameCreateDto gameCreateDto)
		{
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
		[HttpPut]
		public ActionResult<GameUpdateDto> Put([FromBody] GameUpdateDto gameUpdateDto)
		{
			var game = new Game() { Title = gameUpdateDto.Title, Id = gameUpdateDto.Id, CategoryID = gameUpdateDto.CategoryId, Platform = gameUpdateDto.Platform, Year = gameUpdateDto.Year };
			var updated = _gameBusiness.UpdateGame(game);
			return Ok(new GameDto(updated.Id, updated.Title, updated.Category.Name, updated.Platform, updated.Year));
		}


		[HttpDelete("{id:long}")]
		public ActionResult Delete(long id)
		{
			_gameBusiness.DeleteGame(id);
			return NoContent();
		}
	}
}
