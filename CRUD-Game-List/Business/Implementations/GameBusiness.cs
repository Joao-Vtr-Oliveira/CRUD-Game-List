using CRUD_Game_List.Domain.Exceptions;
using CRUD_Game_List.Model;
using CRUD_Game_List.Repositories;

namespace CRUD_Game_List.Business.Implementations
{
	public class GameBusiness : IGameBusiness
	{

		private readonly IGameRepository _repository;

		public GameBusiness(IGameRepository repository)
		{
			_repository = repository;
		}
		public Game AddGame(Game game)
		{
			var trimmed = game.Title?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(trimmed)) throw new ArgumentException("Title is required.", nameof(game.Title));
			if (_repository.ExistsByName(trimmed)) throw new DuplicateGameTitleException(trimmed);
			return _repository.AddGame(game);
		}

		public void DeleteGame(Game game)
		{
			throw new NotImplementedException();
		}

		public Game FindGameById(long id)
		{
			throw new NotImplementedException();
		}

		public List<Game> GetGames()
		{
			return _repository.GetGames();
		}

		public Game UpdateGame(Game game)
		{
			throw new NotImplementedException();
		}
	}
}
