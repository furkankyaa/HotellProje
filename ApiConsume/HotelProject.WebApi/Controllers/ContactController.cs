using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }
        [HttpGet]
        public ActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public ActionResult GetSendMessage(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public ActionResult GetContactCount()
        {
            return Ok(_contactService.TGetContactCount());
        }


    }
}
