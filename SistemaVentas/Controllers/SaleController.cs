using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
