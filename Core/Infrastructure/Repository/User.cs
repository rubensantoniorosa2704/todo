using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Config;

namespace TodoApi.Core.Infrastructure.Repository
{
    public class UserRepository(MyDbContext context) : IUserRepository
    {
        private readonly MyDbContext _context = context;

        public async Task<User?> GetById(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.User.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> List()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Update(User user, int id)
        {
            var existingUser = await _context.User.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
