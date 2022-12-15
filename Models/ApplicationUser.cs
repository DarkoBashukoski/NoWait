using Microsoft.AspNetCore.Identity;

namespace NoWait.Models;

public class ApplicationUser : IdentityUser {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public IEnumerable<Reservation>? Reservations { get; set; }
}