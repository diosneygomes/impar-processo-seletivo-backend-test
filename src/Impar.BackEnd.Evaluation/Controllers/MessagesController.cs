using Microsoft.AspNetCore.Mvc;

namespace Impar.BackEnd.Evaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        [Route("status")]
        public IActionResult Status()
        {
            return Ok("Mostre o status do envio aqui");
        }


        [HttpPost]
        [Route("send")]
        public IActionResult SendMessages()
        {
            return Ok();
        }
    }
}
