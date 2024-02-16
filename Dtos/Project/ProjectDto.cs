using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Dtos;
public class ProjectDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required CompanyDto CompanyDto { get; set; }
    public IEnumerable<TechnologyDto> TechnologiesDto { get; } = new List<TechnologyDto>();
}