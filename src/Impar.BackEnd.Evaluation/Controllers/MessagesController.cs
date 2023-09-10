using Impar.BackEnd.Evaluation.Application.InputModel;
using Impar.BackEnd.Evaluation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Impar.BackEnd.Evaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageApplication _messageApplication;

        public MessagesController(IMessageApplication messageApplication)
        {
                this._messageApplication = messageApplication;
        }

        [HttpGet]
        [Route("status")]
        public IActionResult Status()
        {
            return Ok("Mostre o status do envio aqui");
        }


        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMessages()
        {
            await this._messageApplication
                .SendMessageToAllAsync()
                .ConfigureAwait(true);

            return this.Accepted();
        }
    }
}
