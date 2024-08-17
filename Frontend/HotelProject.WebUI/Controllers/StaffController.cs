using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:5453/api/Staff"); //ilgili adrese istekte bulunduk
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
                var values = JsonConvert.DeserializeObject<List<StaffViwModel>>(jsonData); //tabloda gösterbilecek formata dönüştürdük
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddStaff(AddStaffViewModel model)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5453/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5453/api/Staff?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        //public async Task<ActionResult> UpdateStaff(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:5453/api/Staff?id={id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}


        //public async Task<ActionResult> UpdateStaff(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:5453/api/Staff?id={id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<UpdateStaffViewModel>>(jsonData);
        //        // İlgili staff'ı seçin; bu örnekte, varsayalım ilk elemanı alıyoruz
        //        var staff = values.FirstOrDefault();
        //        return View(staff);
        //    }
        //    return View();
        //}
        public async Task<ActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5453/api/Staff?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UpdateStaffViewModel>>(jsonData);
                // Belirli bir id'ye sahip staff'ı seçin
                var staff = values.FirstOrDefault(s => s.StaffId == id);
                return View(staff);
            }
            return View();
        }


        [HttpPost]
        //public async Task<ActionResult> UpdateStaff(UpdateStaffViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model); // Hataları kullanıcıya göster
        //    }

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(model);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //    var responseMessage = await client.PutAsync($"http://localhost:5453/api/Staff/{model.StaffId}", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index"); // Başarıyla güncellenince Index sayfasına yönlendir
        //    }

        //    // Hata durumunda, hata mesajını veya modelin kendisini geri döndür
        //    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
        //    return View(model);
        //}



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
