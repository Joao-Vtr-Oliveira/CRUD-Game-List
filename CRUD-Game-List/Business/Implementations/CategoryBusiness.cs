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
		public Category AddCategory(string name) => _repository.AddCategory(name);

		public Category FindCategoryById(long id) => _repository.FindCategoryById(id);
	}
}
