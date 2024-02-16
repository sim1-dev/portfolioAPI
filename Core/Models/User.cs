

using Microsoft.AspNetCore.Identity;

namespace PortfolioAPI.Core.Models;

public class User : IdentityUser
{

    public string? FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = string.Empty;

    public ICollection<Company> Companies { get; set; } = new List<Company>();
    //public ICollection<Technology> Technologies { get; set; } = new List<Technology>();
}
