using CRUD_Game_List.Business;
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
			var categories = _gameBusiness.GetGames();
			return Ok(categories);
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
					created.CategoryID,
					created.Platform,
					created.Year
			);

			return CreatedAtAction(nameof(GetById), new { id = created.Id }, dto);
		}

		[HttpGet("{id:long}")]
		public ActionResult<GameDto> GetById(long id)
		{
			var g = _gameBusiness.FindGameById(id);
			return Ok(new GameDto(g.Id, g.Title, g.CategoryID, g.Platform, g.Year));
		}


	}
}
