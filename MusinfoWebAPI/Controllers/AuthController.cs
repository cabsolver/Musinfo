using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusinfoBL;
using MusinfoBL.Services.Interface;
using MusinfoDB.Models;
using MusinfoWebAPI.Requests;
using System.IdentityModel.Tokens.Jwt;

namespace MusinfoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService auth) => _authService = auth;

        [HttpPost]
        [Route("register")]
        public ActionResult Register(RegisterRequest request)
        {
            if (request == null)
                return BadRequest();

            var user = RegisterRequest.GetUserEntity(request);

            var regStatus = _authService.Register(user);
            if (regStatus != "Success")
                return BadRequest(regStatus);

            return Ok(regStatus);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginRequest request)
        {
            if (request == null)
                return BadRequest();


            var token = _authService.Login(request.UserName, request.Password);
            if (token == null)
                return NotFound();

            return Ok(token);
        }

    }
}
