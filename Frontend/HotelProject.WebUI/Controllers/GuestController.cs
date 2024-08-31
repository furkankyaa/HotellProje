using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:5453/api/Guest"); //ilgili adrese istekte bulunduk
            if (responseMessage.IsSuccessStatusCode)

            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData); //tabloda gösterbilecek formata dönüştürdük
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddGuest(CreateGuestDto createGuestDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGuestDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5453/api/Guest", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5453/api/Guest?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public async Task<ActionResult> UpdateGuest(UpdateGuestDto updateGuestDto)
        {
            var client = _httpClientFactory.CreateClient();

            // Doğru GuestID ile istek URL'sini oluşturun
            var responseMessage = await client.GetAsync($"http://localhost:5453/api/Guest?id={updateGuestDto.GuestID}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // Yanıtı tek bir UpdateGuestDto nesnesine deserialize edin
                var guest = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);

                // guest nesnesini view'a geri döndürün
                return View(guest);
            }

            // Yanıt başarılı değilse, boş bir view veya hata view'ı döndürün
            return View();
        }



        [HttpPost]
     


        [HttpPost]
        public async Task<ActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5453/api/Staff/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
