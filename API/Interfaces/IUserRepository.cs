using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{

    void Update(AppUser user);

    Task<bool> SaveAllASync();

    Task<IEnumerable<AppUser>> GetUsersASync();

    Task<AppUser> GetUserByIdAsync(int id);

    Task<AppUser> GetByUserNameAsync( string username);

    Task<IEnumerable<MemberDTO>> GetMembersDTOAsync();

    Task<MemberDTO> GetMemberDTOAsync(string username);

}
