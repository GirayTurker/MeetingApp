using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DBContext _context;
    public UserRepository(DBContext context)
    {
        _context = context;
    }
    public async Task<AppUser> GetByUserNameASync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x=> x.UserName == username);
    }

    public async Task<AppUser> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<AppUser>> GetUsersASync()
    {
        return  await _context.Users.ToListAsync();
    }

    public async Task<bool> SaveAllASync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
