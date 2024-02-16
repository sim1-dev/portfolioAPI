using Microsoft.AspNetCore.Identity;
using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Models;

public class Role : IdentityRole
{
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
