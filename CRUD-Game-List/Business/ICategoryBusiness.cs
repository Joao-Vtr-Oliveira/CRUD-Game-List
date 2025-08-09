using CRUD_Game_List.Model;

namespace CRUD_Game_List.Business
{
	public interface ICategoryBusiness
	{
		Category AddCategory(string name);
		List<Category> GetCategories();
		Category FindCategoryById(long id);
	}
}
