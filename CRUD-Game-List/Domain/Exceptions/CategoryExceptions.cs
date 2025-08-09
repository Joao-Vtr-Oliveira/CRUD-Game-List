namespace CRUD_Game_List.Domain.Exceptions
{
	public sealed class DuplicateCategoryNameException : BaseDomainException
	{
		public string Name { get; }
		public DuplicateCategoryNameException(string name)
				: base($"Category name '{name}' already exists.")
		{
			Name = name;
		}
	}
	public sealed class CategoryNotFoundException : BaseDomainException
	{
		public long Id { get; }
		public CategoryNotFoundException(long id)
				: base($"Category with id '{id}' was not found.")
		{
			Id = id;
		}
	}
}
