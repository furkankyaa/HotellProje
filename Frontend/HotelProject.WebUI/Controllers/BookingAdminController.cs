using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:5453/api/Booking"); //ilgili adrese istekte bulunduk
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData); //tabloda gösterbilecek formata dönüştürdük
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5453/api/bbbb/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
