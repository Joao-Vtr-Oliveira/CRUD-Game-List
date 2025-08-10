using CRUD_Game_List.Model;

namespace CRUD_Game_List.Repositories
{
	public interface ICategoryRepository
	{
		Category AddCategory(string name);
		List<Category> GetCategories();
		Category? FindCategoryById(long id);
		Category UpdateCategory(Category category);
		void DeleteCategory(Category category);
		bool ExistsByName(string name);
	}
}
