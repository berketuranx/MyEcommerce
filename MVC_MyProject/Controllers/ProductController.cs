using Microsoft.AspNetCore.Mvc;
using MyEcommerce.BLL.Abstract;
using MyEcommerce.Entity.Entity;

namespace MVC_MyProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductController(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public IActionResult Index()
        {
           
            return View(_genericRepository.GetAll());
        }
    }
}
