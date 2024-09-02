using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }
        [HttpGet]
        public ActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetByID(id);
            _sendMessageService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetSendMessage(int id)
        {
            var values = _sendMessageService.TGetByID(id);
            return Ok(values);
        }
    }
}
