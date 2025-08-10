using CRUD_Game_List.Domain.Exceptions;
using CRUD_Game_List.Model;
using CRUD_Game_List.Repositories;

namespace CRUD_Game_List.Business.Implementations
{
	public class CategoryBusiness : ICategoryBusiness
	{

		private readonly ICategoryRepository _repository;

		public CategoryBusiness(ICategoryRepository repository)
		{
			_repository = repository;
		}

		public List<Category> GetCategories() => _repository.GetCategories();
		public Category AddCategory(string name)
		{
			var trimmed = name?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(trimmed)) throw new ArgumentException("Name is required.", nameof(name));
			if (_repository.ExistsByName(trimmed)) throw new DuplicateCategoryNameException(trimmed);

			return _repository.AddCategory(trimmed);
		}

		public Category FindCategoryById(long id)
		{
			var cat = _repository.FindCategoryById(id);
			return cat == null ? throw new CategoryNotFoundException(id) : cat;
		}

		public Category UpdateCategory(long id, string name)
		{
			var cat = _repository.FindCategoryById(id)
								?? throw new CategoryNotFoundException(id);

			var trimmed = name?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(trimmed))
				throw new ArgumentException("Name is required.", nameof(name));

			if (!string.Equals(cat.Name, trimmed, StringComparison.OrdinalIgnoreCase))
			{
				if (_repository.ExistsByName(trimmed))
					throw new DuplicateCategoryNameException(trimmed);

				cat.Name = trimmed;
			}

			return _repository.UpdateCategory(cat);
		}

		public void DeleteCategory(long id)
		{
			var cat = _repository.FindCategoryById(id)
					?? throw new CategoryNotFoundException(id);
			_repository.DeleteCategory(cat);
		}
	}
}
