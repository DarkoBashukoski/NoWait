namespace NoWait.Models; 

public class MenuItem {
    public enum FoodCategory {
        Breakfast, Lunch, Dinner, Salad, Appetizer, Dessert, Drink
    }
    
    public int MenuItemID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public FoodCategory foodCategory {get; set;}
    
    public List<Ingredient>? Ingredients { get; set; }
}