﻿using CRUD_Game_List.Model;
using CRUD_Game_List.Model.Context;

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
			if (name == null) return null;
			var category = new Category { Name = name };
			_context.Add(category);
			_context.SaveChanges();

			return category;

		}

		public Category FindCategoryById(long id)
		{
			var cat = _context.Categories.First(c => c.Id == id);
			if (cat != null) return cat;
			return null;
		}

		public List<Category> GetCategories()
		{
			return _context.Categories.ToList();
		}
	}
}
