using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {

        public int ServiceID { get; set; }
        [Required(ErrorMessage = "ICONU GİRİNİZ")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "BAŞLIK GİRİNİZ")]

        public string Title { get; set; }

        [Required(ErrorMessage = "AÇIKLAMA GİRİNİZ")]

        public string Description { get; set; }

    }
}
