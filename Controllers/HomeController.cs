using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NoWait.Data;
using NoWait.Models;

namespace NoWait.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly NoWaitContext _context;

    public HomeController(ILogger<HomeController> logger, NoWaitContext context) {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index() {
        IQueryable<MenuItem>? items = _context.MenuItems.Where(i => i.MenuItemID == 16 
                                                                    || i.MenuItemID == 23 
                                                                    || i.MenuItemID == 26);
        return View(items);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}