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
    }

