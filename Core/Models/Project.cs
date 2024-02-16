using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioAPI.Core.Models;

[Table("projects")]
public class Project {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public required string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public virtual int CompanyId {get; set;}
    public Company? Company {get; set;}
    public ICollection<Technology>? Technologies { get; set; } = new List<Technology>();
}