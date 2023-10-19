using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authManager;
        public AuthController(IAuthService authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var exsitUser = _authManager.UserExsist(userForRegisterDto.Email);
            if (!exsitUser.Success)
            {
                return BadRequest(exsitUser.Message);
            }

            var redistedUser = _authManager.Register(userForRegisterDto);
            var accessToken = _authManager.CreateAccessToken(redistedUser.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }

            return BadRequest(accessToken.Message);



        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var loginUser = _authManager.Login(userForLoginDto);
            if (!loginUser.Success)
            {
                return BadRequest(loginUser.Message);
            }
            var accestoken = _authManager.CreateAccessToken(loginUser.Data);
            if (accestoken.Success)
            {
                return Ok(accestoken.Data);
            }
            return BadRequest(accestoken.Message);


        }
        [HttpGet("getUser")]
        public ActionResult GetUser(string email)
        {
            var user = _authManager.GetUser(email);
          
           
            
                return Ok(user);
    


        }

    }
}
