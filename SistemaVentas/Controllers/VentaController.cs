using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
