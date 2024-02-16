using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Dtos;
public class UpdateProjectDto
{    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? EndDate { get; set; }
}