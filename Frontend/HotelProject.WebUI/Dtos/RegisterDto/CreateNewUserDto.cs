using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "İSİM GEREKLİDİR")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "SOYİSİM GEREKLİDİR")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Kullanıcı Adı GEREKLİDİR")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mail GEREKLİDİR")]
        public string Mail { get; set; }
        
        [Required(ErrorMessage = "Şifre GEREKLİDİR")]
        public string Password {get; set; } 
        
        [Required(ErrorMessage = "Şifre TEKRAR GEREKLİDİR")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword {get; set; }


    }
}
