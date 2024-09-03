using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }
        [HttpGet]
        public ActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TInsert(messageCategory);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            return Ok(values);
        }
    }
}
