using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
