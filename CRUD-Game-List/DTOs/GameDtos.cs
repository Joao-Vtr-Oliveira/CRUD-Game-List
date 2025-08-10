using CRUD_Game_List.Model;

namespace CRUD_Game_List.DTOs
{
	public class GameDtos
	{
		public record GameCreateDto(string Title, long CategoryId, string? Platform, int? Year);
		public record GameUpdateDto(long Id, string Title, long CategoryId, string? Platform, int? Year);
		public record GameDto(long Id, string Title, long CategoryId, string? Platform, int? Year);
	}

}
