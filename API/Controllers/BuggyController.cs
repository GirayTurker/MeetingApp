using System.Data.Common;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController:BaseAPIController
{
    private readonly DBContext _dbContext;

    public BuggyController(DBContext dBContext)
    {
        _dbContext = dBContext;
    }

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string>GetSecret()
    {
       return "screen text";     
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser>GetNotFound()
    {
       var thing = _dbContext.Users.Find(-1);

       if(thing == null) {return NotFound();}

       return thing;   
    }

    [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

         var thing = _dbContext.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
         /*
         try
         {
            var thing = _dbContext.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
         }
         catch(Exception ex)
         {
            return StatusCode(500, "Server Error Occured");
         }
          */  
        }

    [HttpGet("bad-request")]
    public ActionResult<string>GetBadRequest()
    {
       return BadRequest("This is Bad Request");    
    }
    
}
