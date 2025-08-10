using CRUD_Game_List.Model;
using CRUD_Game_List.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Game_List.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly PostgreSQLContext _context;

		public CategoryRepository(PostgreSQLContext context)
		{
			_context = context;
		}

		public Category AddCategory(string name)
		{
			var category = new Category { Name = name.Trim() };
			_context.Add(category);
			_context.SaveChanges();
			return category;

		}

		public bool ExistsByName(string name)
		{
			var trimmed = name.Trim();
			return _context.Categories.AsNoTracking().Any(c => c.Name.ToLower() == trimmed.ToLower());
		}

		public Category? FindCategoryById(long id)
		{
			var cat = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
			return cat;
		}

		public List<Category> GetCategories()
		{
			return _context.Categories.AsNoTracking().ToList();
		}

		public Category UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
			return category;
		}
		public void DeleteCategory(Category category)
		{
			_context.Categories.Remove(category);
			_context.SaveChanges();
		}
	}
}
