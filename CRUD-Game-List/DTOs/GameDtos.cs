using CRUD_Game_List.Model;

namespace CRUD_Game_List.DTOs
{
	public class GameDtos
	{
		public record GameCreateDto(string Title, long CategoryId, string ?Plataform, int ?Year);

		public record GameUpdateDto(string Title, long CategoryId, string? Plataform, int? Year);

		public record GameDto(long Id, string Title, long CategoryId, Category Cat, string? Plataform, int? Year);
	}
}
