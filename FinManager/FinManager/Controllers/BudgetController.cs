using Microsoft.AspNetCore.Mvc;

namespace FinManager.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
