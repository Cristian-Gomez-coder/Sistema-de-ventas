using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class ArticuloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
