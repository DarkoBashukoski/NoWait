using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoWait.Data;

namespace NoWait.Controllers; 

public class ReservationController : Controller
{
    private readonly NoWaitContext _context;

    public ReservationController(NoWaitContext context)
    {
        _context = context;
    }

    // GET: Reservation
    public IActionResult Index() {
        return View();
    }

    private bool ReservationExists(int id)
    {
        return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
    }
}