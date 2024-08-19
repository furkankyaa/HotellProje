using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Servis İkon Linki Giriniz")]
        public int ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En Fazla 100 Karakter Olabilir")]

        public int Title { get; set; }
        public int Description { get; set; }
    }
}

