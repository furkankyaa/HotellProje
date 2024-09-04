using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }
        [HttpGet]
        public ActionResult RoomList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddGuest(WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteGuest(int id)
        {
            var values = _workLocationService.TGetByID(id);
            _workLocationService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateGuest(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetGuest(int id)
        {
            var values = _workLocationService.TGetByID(id);
            return Ok(values);
        }
    }
}
