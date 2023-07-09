using System;
using ShopStore.Data.Context;
using ShopStore.Data.Models;
using ShopStore.Data.Repository.Contracts;

namespace ShopStore.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
	private DataContext _context;
	public CategoryRepository(DataContext context)
	{
		_context = context;
	}

	public IEnumerable<Category> GetCategories()
	{
		return _context.Categories.ToList();
	}
}

