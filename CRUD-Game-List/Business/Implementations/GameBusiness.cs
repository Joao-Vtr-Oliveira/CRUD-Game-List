using CRUD_Game_List.Domain.Exceptions;
using CRUD_Game_List.Model;
using CRUD_Game_List.Repositories;

namespace CRUD_Game_List.Business.Implementations
{
	public class GameBusiness : IGameBusiness
	{

		private readonly IGameRepository _repository;
		private readonly ICategoryRepository _catRepository;

		public GameBusiness(IGameRepository repository, ICategoryRepository catRepository )
		{
			_repository = repository;
			_catRepository = catRepository;
		}
		public Game AddGame(Game game)
		{
			var trimmed = game.Title?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(trimmed)) throw new ArgumentException("Title is required.", nameof(game.Title));
			if (_repository.ExistsByName(trimmed)) throw new DuplicateGameTitleException(trimmed);
			_catRepository.FindCategoryById(game.CategoryID);
			return _repository.AddGame(game);
		}

		public void DeleteGame(long id)
		{
			var game = _repository.FindGameById(id) ?? throw new GameNotFoundException(id);
			_repository.DeleteGame(game);
		}

		public Game FindGameById(long id)
		{
			var game = _repository.FindGameById(id) ?? throw new GameNotFoundException(id);
			return game;
		}

		public List<Game> GetGames()
		{
			return _repository.GetGames();
		}

		public Game UpdateGame(Game game)
		{
			var trimmed = game.Title?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(trimmed)) throw new ArgumentException("Title is required.", nameof(game.Title));
			if (_repository.ExistsByName(trimmed)) throw new DuplicateGameTitleException(trimmed);
			_catRepository.FindCategoryById(game.CategoryID);
			if(_repository.FindGameById(game.Id) == null) throw new GameNotFoundException(game.Id);
			return _repository.UpdateGame(game);
		}
	}
}
