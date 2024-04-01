using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UserController : BaseAPIController
{
    //private readonly DBContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        //_dbContext = dbContext;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    //HTTP ENDPOINTS!!

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
    {
        var users = await _userRepository.GetMembersDTOASync();


        return Ok(users);

        //return users; //200 Ok Response
    }

    [HttpGet("{username}")] //api/user/2

    public async Task<ActionResult<MemberDTO>> GetUser(string username)
    {
        return  await _userRepository.GetMemberDTOAsync(username);

    }
}
