namespace PortfolioAPI.Dtos;

public class CreateCompanyDto {
    public required string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}