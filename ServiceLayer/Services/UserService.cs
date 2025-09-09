using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService
    {
        public static readonly ElectronicTextbookContext _context = new();

        public async Task<User?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserLogin == login && u.UserPassword == password);
        }
    }
}
