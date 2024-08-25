using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public ActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public ActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut("aaaaa")]
        public IActionResult  aaaaa(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpPut("bbbb")]
        public IActionResult bbbb(int id)
        {
            _bookingService.TBookingStatusChangeApproved2(id);
            return Ok();
        }

    }
}

