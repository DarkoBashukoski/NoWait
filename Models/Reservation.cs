namespace NoWait.Models; 

public class Reservation {
    public int ReservationId { get; set; }

    public ApplicationUser User { get; set; }
    public Table Table { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}