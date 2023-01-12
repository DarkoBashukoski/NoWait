using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NoWait.Data;
using NoWait.Models;

namespace NoWait.Controllers;

public class ReservationController : Controller {
    private readonly NoWaitContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly Dictionary<string, WorkingHours> _workingHoursMap;

    public ReservationController(NoWaitContext context, UserManager<ApplicationUser> userManager) {
        _context = context;
        _userManager = userManager;
        _workingHoursMap = new Dictionary<string, WorkingHours> {
            ["Mon"] = new(9, 18),
            ["Tue"] = new(9, 18),
            ["Wed"] = new(9, 18),
            ["Thu"] = new(9, 20),
            ["Fri"] = new(9, 18),
            ["Sat"] = new(10, 18),
            ["Sun"] = new(11, 16)
        };
    }

    // GET: Reservation
    [Authorize]
    public IActionResult Index() {
        return View();
    }

    public IActionResult Selection() {
        return View(_context.MenuItems);
    }
    
    public IActionResult Payment() {
        return View();
    }

    public int SubmitTable(int year, int month, int day, int hour, int tableId) {
        
        string userId = _userManager.GetUserId(User);
        Reservation Previous = _context.Reservations.FirstOrDefault(i => i.User.Id == userId && i.IsFinished == false);
        if (Previous != null) {
            _context.Reservations.Remove(Previous);
            _context.SaveChanges();
        }
        
        
        Reservation r = new Reservation {
            Year = year,
            Month = month,
            Day = day,
            Hour = hour,
            Table = _context.Tables.First(t => t.TableId == tableId),
            User = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result,
            IsFinished = false
        };

        _context.Add(r);
        _context.SaveChanges();
        
        return r.ReservationId;
    }

    public IActionResult SubmitReservation(IFormCollection formCollection) {
        string userId = _userManager.GetUserId(User);
        Reservation r = _context.Reservations.First(i => i.User.Id == userId);
        r.Orders = new List<Order>();
        foreach (string order in formCollection["orders"]) {
            dynamic ord = JObject.Parse(order);
            string itemName = ord["menuItemName"];
            string count = ord["count"];
            MenuItem i = _context.MenuItems.First(i => i.Name == itemName);
            Order o = new Order {
                Count = Int32.Parse(count),
                Item = i
            };
            r.Orders.Add(o);
        }

        // r.IsFinished = true;
        _context.Update(r);
        _context.SaveChanges();
        
        return RedirectToAction(nameof(Payment));
    }

    private bool ReservationExists(int id) {
        return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
    }

    public List<int> GetAvailableReservations(int year, int month, int day, int tableId) {
        var takenReservations = _context.Reservations!
            .Where(t => t.Table.TableId == tableId && t.Year == year && t.Month == month && t.Day == day);

        WorkingHours hours = _workingHoursMap[GetDayOfWeek(year, month, day)];
        List<int> output = new List<int>();
        for (int i = hours.Opening; i < hours.Closing; i++) {
            output.Add(i);
        }

        foreach (var r in takenReservations) {
            if (output.Contains(r.Hour)) {
                output.Remove(r.Hour);
            }
        }

        return output;
    }

    public List<Table> GetAllTables() {
        return _context.Tables.ToList();
    }

    public List<Chair> GetAllChairs() {
        return _context.Charis.ToList();
    }

    public List<Wall> GetAllWalls() {
        return _context.Walls.ToList();
    }

    private string GetDayOfWeek(int year, int month, int day) {
        return new DateTime(year, month, day).ToString("ddd");
    }

    public IActionResult ConfirmPayment() {
        string userId = _userManager.GetUserId(User);
        Reservation r = _context.Reservations.First(i => i.User.Id == userId);
        r.IsFinished = true;

        _context.Reservations.Update(r);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    private class WorkingHours {
        public int Opening { get; }
        public int Closing { get; }

        public WorkingHours(int opening, int closing) {
            Opening = opening;
            Closing = closing;
        }
    }
    
}