using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
