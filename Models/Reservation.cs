namespace NoWait.Models; 

public class Reservation {
    public int ReservationId { get; set; }

    public Table Table { get; set; }
    public List<Order> Orders { get; set; }
}