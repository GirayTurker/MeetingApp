using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API.Controllers;

public class AccountController:BaseAPIController
{
    private readonly DBContext _dbContext;

    private readonly ITokenService _tokenService;
    public AccountController(DBContext dbContext, ITokenService tokenService)
    {
        _dbContext = dbContext;
        _tokenService = tokenService;
    }

    [HttpPost("register")] //api/account/register

    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
        if(await UserExist(registerDTO.UserName))
        {
            return BadRequest("User name is exist");
        }

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDTO.UserName.ToLower(),
            PasswordHash = ComputeHashValue(hmac, registerDTO.Password), //hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
            PasswordSalt = hmac.Key
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return new UserDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(
            option => option.UserName == loginDTO.Username);

            if(user == null)
            {
                return Unauthorized("Invalid Username");
            }

        using var hmac = new HMACSHA512(user.PasswordSalt);

        //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

         var computedHash = ComputeHashValue(hmac,loginDTO.Password);

        for (int i=0; computedHash.Length>i; i++)
        {
            if(computedHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid Password");
            }
        }

         return new UserDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    private async Task<bool>UserExist(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.UserName == username.ToLower());
    }

    private byte[] ComputeHashValue(HMACSHA512 hmac, string objAndParam)
    {
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(objAndParam));
        return computedHash;
    }
}
