using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_MyProject.Models.ViewModel;
using MyEcommerce.Common;
using MyEcommerce.DAL.Context;
using MyEcommerce.Entity.Entity;
using System.Web;

namespace MVC_MyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager,  SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = registerVM.Username;
                user.Email = registerVM.Email;



                var result = await _userManager.CreateAsync(user, registerVM.ConfirmPassword);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);   
                    var encodedToken = HttpUtility.UrlEncode(token);


                    string confirmationLink = Url.Action("Confirmation", "User", new {id= user.Id, token= encodedToken},Request.Scheme );
                    MailSender.SendEmail(registerVM.Email,"Confirmation", $"{registerVM.Username} kayıt işleminiz başarılı! Üyeliğinizi aktif hale getirebilmek için linke tıklayınız.{confirmationLink} ");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(registerVM);
                }


            }
            else
            {

                return View(registerVM);
            }

        }

        public async Task<IActionResult> Confirmation(string? id, string? token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Create");
            }
            var decodedToken = HttpUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (result.Succeeded)
            {
                return View("Index", "Home");
            }
            return RedirectToAction("Create");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (ModelState.IsValid)
            {
                var login = await _userManager.FindByNameAsync(loginvm.Username);
                if (login != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(login, loginvm.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else { return View(loginvm); }
                }
                else
                {
                    return View() ;
                }
                
            }
            else
            {
                return View(loginvm);
            }
           
        }
    }
}
