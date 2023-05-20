using System.ComponentModel.DataAnnotations;

namespace MVC_MyProject.Models.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Email boş bırakılamaz"!)]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Şifre boş bırakılamaz!")]
        [Display(Name = "Şifre")]

        public string Password { get; set; }
        [Required(ErrorMessage ="Şifre boş bırakılamaz!")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }


    }
}
