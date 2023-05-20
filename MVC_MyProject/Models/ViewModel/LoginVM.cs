
using System.ComponentModel.DataAnnotations;


namespace MVC_MyProject.Models.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilmez")]
        [Display(Name ="Kullanıcı adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilmez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
