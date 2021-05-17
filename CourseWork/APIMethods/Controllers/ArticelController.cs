using BLL.BusinessInterfaces;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly IService<Author> _articleService;

        public ArticleController(IService<Author> articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var article = _articleService.GetAll().FirstOrDefault(e => e.Id == id);
            return Json(article);
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody] Author article)
        {
            var id = _articleService.Add(article);
            if (id > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                _articleService.Remove(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
