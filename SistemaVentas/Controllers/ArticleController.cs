using Microsoft.AspNetCore.Mvc;

namespace SistemaVentas.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
