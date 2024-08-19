using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz")]
        public int ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En Fazla 100 Karakter Olabilir")]

        public int Title { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklaması Giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Başlığı En Fazla 500 Karakter Olabilir")]
        public int Description { get; set; }
    }
}
