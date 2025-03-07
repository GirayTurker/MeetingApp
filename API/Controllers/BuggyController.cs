﻿using System.Data.Common;
using System.Net;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<AppUser>GetNotFound()
    {
       var thing = _dbContext.Users.Find(-1);

       if(thing == null) { return StatusCode((int)HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Data = NotFound("Not Found"), StatusText = "Not Found" });;}

           // Custom response including status code, data, and status text
    return thing;
 
    }

    [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

         var thing = _dbContext.Users.Find(-1);

            var thingToReturn = StatusCode((int)HttpStatusCode.InternalServerError, new { StatusCode = HttpStatusCode.InternalServerError, Data = HttpStatusCode.InternalServerError, StatusText = "Server Not Found" });

            return thingToReturn;
         /* USE FOR ""NOT"" MIDDLEWARE
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
       return StatusCode((int)HttpStatusCode.BadRequest, new { StatusCode = HttpStatusCode.BadRequest, Data =  BadRequest("This is bad Request"), StatusText = "This is bad Request" });    
    }
    
}
