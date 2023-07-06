using System;
using ShopStore.Data;
using ShopStore.Models;
using ShopStore.Repository.Contracts;

namespace ShopStore.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public bool AddUser(User user)
    {
        _context.Add(user);
        return Save();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetUser(int Id)
    {
        return _context.Users.Where(u => u.Id == Id).FirstOrDefault()!;
    }

    public bool UserExists(int Id)
    {
        if (_context.Users.Where(u => u.Id == Id).FirstOrDefault() != null)
            return true;
        else
            return false;
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool CheckUser(string email)
    {
        if (_context.Users.Where(u => u.Email == email).FirstOrDefault() != null)
            return true;
        else
            return false;
    }
}

