using BLL.BusinessInterfaces;
using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : Controller
    {
        private readonly IService<Topic> _topicService;

        public TopicController(IService<Topic> topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var topic = _topicService.GetAll().FirstOrDefault(e => e.Id == id);
            return Json(topic);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Topic topic)
        {
            try
            {
                var id = _topicService.Add(topic);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public StatusCodeResult Put([FromBody] Topic topic)
        {
            try
            {
                _topicService.Update(topic);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                _topicService.Remove(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
