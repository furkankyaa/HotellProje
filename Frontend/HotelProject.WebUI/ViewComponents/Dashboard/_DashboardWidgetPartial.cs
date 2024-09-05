using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial :ViewComponent 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:5453/api/DashboardWidget/StaffCount"); //ilgili adrese istekte bulunduk
            var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
            ViewBag.v1 = jsonData;


            var client2 = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage2 = await client2.GetAsync("http://localhost:5453/api/DashboardWidget/BookingCount"); //ilgili adrese istekte bulunduk
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
            ViewBag.v2 = jsonData2;

            var client3 = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage3 = await client3.GetAsync("http://localhost:5453/api/DashboardWidget/AppUserCount"); //ilgili adrese istekte bulunduk
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
            ViewBag.v3 = jsonData3;
            
            
            
            var client4 = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage4 = await client4.GetAsync("http://localhost:5453/api/DashboardWidget/RoomCount"); //ilgili adrese istekte bulunduk
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();   //gelen veriyi jsondataya atadık
            ViewBag.v4 = jsonData4;

            return View();
        }






    }
}
