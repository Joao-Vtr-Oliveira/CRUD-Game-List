using CRUD_Game_List.Model;

namespace CRUD_Game_List.Repositories
{
	public interface IGameRepository
	{
		Game AddGame(string name);
		List<Game> GetGames();
		Game? FindGameById(long id);
		Game UpdateGame(Game game);
		void DeleteGame(Game game);
		bool ExistsByName(string name);
	}
}
