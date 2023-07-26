using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
