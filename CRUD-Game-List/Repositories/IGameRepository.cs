using CRUD_Game_List.Model;

namespace CRUD_Game_List.Repositories
{
	public interface IGameRepository
	{
		Game AddGame(Game game);
		List<Game> GetGames();
		Game? FindGameById(long id);
		Game UpdateGame(Game game);
		void DeleteGame(Game game);
		bool ExistsByName(string title);
	}
}
