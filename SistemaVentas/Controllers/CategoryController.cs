using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
