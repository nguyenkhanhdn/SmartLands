using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartLands.Models;

namespace SmartLands.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<LandLog> logs = new List<LandLog>();
        FirebaseUtil firebaseUtil = new FirebaseUtil();
        logs = firebaseUtil.GetLogs();

        return View(logs);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
