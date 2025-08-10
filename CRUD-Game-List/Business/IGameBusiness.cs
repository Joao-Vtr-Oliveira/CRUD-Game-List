using CRUD_Game_List.Model;

namespace CRUD_Game_List.Business
{
	public interface IGameBusiness
	{
		Game AddGame(Game game);
		List<Game> GetGames();
		Game FindGameById(long id);
		Game UpdateGame(Game game);
		void DeleteGame(long id);
	}
}
