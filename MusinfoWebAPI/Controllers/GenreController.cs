using Microsoft.AspNetCore.Mvc;
using MusinfoBL.Services.Interface;
using MusinfoDB.Models;
using MusinfoWebAPI.Requests;
using MusinfoWebAPI.Responses;

namespace MusinfoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IService<Genre> _service;

        public GenreController(IService<Genre> service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<GenreResponse>> Get()
        {
            var genres = _service.Get();
            var model = genres.
                Select(x => new GenreResponse
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return new ObjectResult(model);
        }

        [HttpGet("id")]
        public ActionResult<IEnumerable<GenreResponse>> Get(int id)
        {
            var genre = _service.Get(id);
            if (genre == null)
                return NotFound();

            var model = GenreResponse.GetGenreResponse(genre);
            return new ObjectResult(model);
        }

        [HttpPost]
        public ActionResult Post(GenreRequest request)
        {
            if (request == null)
                return BadRequest();

            var isExists = _service.Exists(x => x.Name == request.Name);
            if (isExists)
                return BadRequest("Genre is already exists");

            var genre = GenreRequest.GetGenreEntity(request);
            _service.Create(genre);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(GenreRequest request)
        {
            if (request == null)
                return BadRequest();

            var isExists = _service.Exists(x => x.Id == request.Id);
            if (!isExists)
                return NotFound();

            var genre = _service.FirstOrDefault(x => x.Id == request.Id);
            genre.Name = request.Name;

            _service.Update(genre);
            return Ok();
        }

        [HttpDelete]
        [Route("id/{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var genre = _service.Get(id);
            if (genre == null)
                return NotFound();

            _service.Delete(id);
            return Ok();
        }

        [HttpDelete]
        [Route("name/{name}")]
        public ActionResult Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var genre = _service.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (genre == null)
                return NotFound();

            var id = genre.Id;
            _service.Delete(id);
            return Ok();
        }
    } 
}
