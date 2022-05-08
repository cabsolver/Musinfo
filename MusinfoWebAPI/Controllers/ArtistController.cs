using Microsoft.AspNetCore.Authorization;
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
    public class ArtistController : ControllerBase
    {
        private readonly IService<Artist> _service;

        public ArtistController(IService<Artist> service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<ArtistResponse>> Get()
        {
            var artists = _service.Get();
            var model = artists.
                Select(x => new ArtistResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Biography = x.Biography
                });

            return new ObjectResult(model);
        }

        [HttpGet]
        [Route("id/{id}")]
        public ActionResult<IEnumerable<ArtistResponse>> Get(int id)
        {
            var artist = _service.Get(id);
            if (artist == null)
                return NotFound();

            var model = ArtistResponse.GetArtistResponse(artist);
            return new ObjectResult(model);
        }

        [HttpGet]
        [Route("name/{name}")]
        public ActionResult<IEnumerable<ArtistResponse>> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var artist = _service.FirstOrDefault(x => x.Name == name);
            if (artist == null)
                return NotFound();

            var model = ArtistResponse.GetArtistResponse(artist);
            return new ObjectResult(model);
        }

        [HttpPost]
        public ActionResult Post(ArtistRequest request)
        {
            if (request == null)
                return BadRequest();

            var isExists = _service.Exists(x => x.Name == request.Name);
            if (isExists)
                return BadRequest("Artist is already exists");

            var artist = ArtistRequest.GetArtistEntity(request);
            _service.Create(artist);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(ArtistRequest request)
        {
            if (request == null)
                return BadRequest();

            var isExists = _service.Exists(x => x.Id == request.Id);
            if (!isExists)
                return NotFound();

            var artist = _service.FirstOrDefault(x => x.Id == request.Id);
            artist.Name = request.Name;
            artist.Biography = request.Biography;

            _service.Update(artist);
            return Ok();
        }

        [HttpDelete]
        [Route("id/{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var artist = _service.Get(id);
            if (artist == null)
                return NotFound();

            _service.Delete(id);
            return Ok();
        }

        [HttpDelete]
        [Route("name/{name}")]
        public ActionResult Delete(string name)
        {
            if(string.IsNullOrEmpty(name))
                return BadRequest();

            var artist = _service.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (artist == null)
                return NotFound();

            var id = artist.Id;
            _service.Delete(id);
            return Ok();
        }
    }
}
