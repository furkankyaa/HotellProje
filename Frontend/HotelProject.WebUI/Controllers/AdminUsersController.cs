using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
   

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //    var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            //    var responseMessage = await client.GetAsync("http://localhost:5453/api/AppUser"); //ilgili adrese istekte bulunduk
            //    if (responseMessage.IsSuccessStatusCode)

            //    {
            //        var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
            //        var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData); //tabloda gösterbilecek formata dönüştürdük
            //        return View(values);
            //    }
            return View();
    }
    public async Task<IActionResult> UserList()

        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:5453/api/AppUser"); //ilgili adrese istekte bulunduk
            if (responseMessage.IsSuccessStatusCode)

            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData); //tabloda gösterbilecek formata dönüştürdük
                return View(values);
            }
            return View();

        }

    }
}
