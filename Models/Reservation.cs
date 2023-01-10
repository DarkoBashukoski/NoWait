namespace NoWait.Models; 

public class Reservation {
    public int ReservationId { get; set; }

    public ApplicationUser User { get; set; }
    public Table Table { get; set; }
    public List<Order> Orders { get; set; }
    
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }
    public bool IsFinished { get; set; }
}