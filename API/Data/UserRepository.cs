using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DBContext _context;

    private readonly IMapper _mapper;
    public UserRepository(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<AppUser> GetByUserNameAsync(string username)
    {
        //include related data (in this case Photo for the user)
        return await _context.Users
        .Include(p=>p.Photos)
        .SingleOrDefaultAsync(x=> x.UserName == username);
        
    }

    public async Task<MemberDTO> GetMemberDTOAsync(string username)
    {
        return await _context.Users
        .Where(x => x.UserName == username)
        .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberDTO>> GetMembersDTOAsync()
    {
        return await _context.Users
        .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<AppUser>> GetUsersASync()
    {
        //include related data (in this case Photo for the user)        
        return  await _context.Users
                .Include(p=>p.Photos)
                .ToListAsync();
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
