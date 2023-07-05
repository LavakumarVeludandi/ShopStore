using System;
using ShopStore.Models;

namespace ShopStore.Repository.Contracts;

public interface IUserRepository
{
    public User GetUser(int Id);
    public bool UserExists(int Id);
    public IEnumerable<User> GetAll();
}

