using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoWait.Data;

namespace NoWait.Controllers; 

public class AdminController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly NoWaitContext _context;
    
    public AdminController(ILogger<HomeController> logger, NoWaitContext context) {
        _logger = logger;
        _context = context;
    }
    
    public IActionResult Index() {
        return View(_context.Reservations.Where(i => i.IsFinished == true)
            .Include(i => i.Table)
            .Include(i => i.Orders));
    }
}