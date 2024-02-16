using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioAPI.Core.Models;

[Table("companies")]
public class Company {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public required string Name { get; set; } = "";
    public required DateTime Start { get; set; }
    public DateTime End { get; set; }
    public ICollection<Project>? Projects { get; } = new List<Project>();

}