using Microsoft.AspNetCore.Mvc;

namespace E_commerce_Project.Controllers;

public class ProductController : Controller
{
    public IActionResult Index(int id)
    {
        return View();
    }
}