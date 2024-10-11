using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {

        [Required(ErrorMessage ="ICONU GİRİNİZ")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "BAŞLIK GİRİNİZ")]
        [StringLength(50,ErrorMessage ="Başlık en fazla 50 Karakter olabilir" )]
        public string Title { get; set; }

        [Required(ErrorMessage = "AÇIKLAMA GİRİNİZ")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması en fazla 500 Karakter olabilir")]

        public string Description { get; set; }

    }
}
