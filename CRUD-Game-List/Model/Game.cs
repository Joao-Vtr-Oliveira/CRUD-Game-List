namespace CRUD_Game_List.Model
{
	public class Game
	{
		public long Id { get; set; }
		public string Title { get; set; } = default!;
		public string? Platform { get; set; }
		public int? Year { get; set; }

		public long CategoryID { get; set; }
		public Category Category { get; set; } = default!;
	}
}
