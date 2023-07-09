using System;
using ShopStore.Data.Models;

namespace ShopStore.Data.Repository.Contracts;

public interface ICategoryRepository
{
    public IEnumerable<Category> GetCategories();

}

