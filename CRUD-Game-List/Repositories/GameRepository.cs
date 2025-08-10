using CRUD_Game_List.Model;
using CRUD_Game_List.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CRUD_Game_List.Repositories
{
	public class GameRepository : IGameRepository
	{

		private readonly PostgreSQLContext _context;

		public GameRepository(PostgreSQLContext context)
		{
			_context = context;
		}

		public Game AddGame(Game game)
		{
			_context.Games.Add(game);
			_context.SaveChanges();
			_context.Entry(game)
				.Reference(g => g.Category)
				.Load();
			return game;
		}

		public void DeleteGame(Game game)
		{
			_context.Games.Remove(game);
			_context.SaveChanges();
		}

		public bool ExistsByName(string title)
		{
			var trimmed = title.Trim();
			return _context.Games.AsNoTracking().Any(c => c.Title.ToLower() == trimmed.ToLower());
		}

		public Game? FindGameById(long id)
		{
			return _context.Games
					.AsNoTracking()
					.Include(g => g.Category)
					.FirstOrDefault(g => g.Id == id);
		}

		public List<Game> GetGames()
		{
			return _context.Games
		.AsNoTracking()
		.Include(g => g.Category)
		.ToList();
		}

		public Game UpdateGame(Game game)
		{
			_context.Games.Update(game);
			_context.SaveChanges();
			_context.Entry(game).Reference(g => g.Category).Load();
			return game;
		}
	}
}
