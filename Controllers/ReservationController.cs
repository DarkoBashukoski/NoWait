using Microsoft.AspNetCore.Mvc;
using NoWait.Data;
using NoWait.Models;

namespace NoWait.Controllers;

public class ReservationController : Controller {
    private readonly NoWaitContext _context;
    private readonly Dictionary<string, WorkingHours> _workingHoursMap;

    public ReservationController(NoWaitContext context) {
        _context = context;
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
    public IActionResult Index() {
        return View();
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

    private class WorkingHours {
        public int Opening { get; }
        public int Closing { get; }

        public WorkingHours(int opening, int closing) {
            Opening = opening;
            Closing = closing;
        }
    }
}