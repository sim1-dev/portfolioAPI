using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Dtos;
public class CreateProjectDto
{    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CompanyId { get; set; } = 1;
}