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
    public IActionResult AddLog()
    {
        FirebaseUtil firebaseUtil = new FirebaseUtil();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int value = new Random().Next(1,20);
        firebaseUtil.SaveLog(date, value);
        // Lưu log vào Firebase
        // Chuyển hướng về trang chính hoặc thực hiện hành động khác
        return RedirectToAction("Index");
        
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
