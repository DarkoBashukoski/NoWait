namespace NoWait.Models; 

public class Order {
    public int OrderId { get; set; }
    public int Count { get; set; }
    
    public MenuItem Item { get; set; }
}