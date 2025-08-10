namespace CRUD_Game_List.Domain.Exceptions
{
	public sealed class DuplicateGameTitleException : BaseDomainException
	{
		public string Name { get; }
		public DuplicateGameTitleException(string name)
				: base($"Game Title '{name}' already exists.")
		{
			Name = name;
		}
	}
	public sealed class GameNotFoundException : BaseDomainException
	{
		public long Id { get; }
		public GameNotFoundException(long id)
				: base($"Game with id '{id}' was not found.")
		{
			Id = id;
		}
	}
}
