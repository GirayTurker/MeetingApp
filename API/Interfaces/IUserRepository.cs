using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{

    void Update(AppUser user);

    Task<bool> SaveAllASync();

    Task<IEnumerable<AppUser>> GetUsersASync();

    Task<AppUser> GetUserById(int id);

    Task<AppUser> GetByUserNameASync( string username);

    Task<IEnumerable<MemberDTO>> GetMembersDTOASync();

    Task<MemberDTO> GetMemberDTOAsync(string username);

}
