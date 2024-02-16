using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Dtos;

public class CompanyDto 
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
  public IEnumerable<ProjectDto> ProjectsDto { get; } = new List<ProjectDto>();
}
