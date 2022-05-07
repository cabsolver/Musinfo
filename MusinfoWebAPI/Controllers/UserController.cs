using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusinfoBL.Services.Interface;
using MusinfoDB.Models;
using MusinfoWebAPI.Requests;
using MusinfoWebAPI.Responses;

namespace MusinfoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _service;

        public UserController(IService<User> service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> Get()
        {
            var users = _service.Get();
            var model = users
                .Select(x => new UserResponse
                {
                    Id = x.Id,
                    Email = x.Email,
                    UserName = x.UserName,
                    Password = x.Password,
                    RoleId = x.RoleId,
                });

            return new ObjectResult(model);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UserResponse>> Get(int id)
        {
            var user = _service.Get(id);
            if (user == null)
                return NotFound();

            var model = UserResponse.GetUserResponse(user);

            return new ObjectResult(model);
        }

        [HttpPost]
        public ActionResult Post(UserRequest request)
        {
            if (request == null)
                return BadRequest();

            var user = UserRequest.GetUserEntity(request);
            _service.Create(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(UserRequest request)
        {
            if (request == null)
                return BadRequest();

            var isExists = _service.Exists(x => x.Id == request.Id);
            if (!isExists)
                return NotFound();

            var user = _service.Get(request.Id);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.RoleId = request.RoleId;

            _service.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var user = _service.Get(id);
            if (user == null)
                return NotFound();

            _service.Delete(id);
            return Ok();
        }
    }
}
