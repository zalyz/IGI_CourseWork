using BLL.BusinessInterfaces;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IService<Author> _authorService;

        public AuthorController(IService<Author> authorService)
        {
            _authorService = authorService;
        }

        // GET: Article/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var author = _authorService.GetAll().FirstOrDefault(e => e.Id == id);
            return Json(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            try
            {
                var id = _authorService.Add(author);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Article/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                _authorService.Remove(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public StatusCodeResult Update([FromBody] Author author)
        {
            try
            {
                _authorService.Update(author);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
