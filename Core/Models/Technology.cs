using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioAPI.Core.Models;

[Table("technologies")]
public class Technology {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public required string Name { get; set; } = "";

    public ICollection<Project>? Projects { get; } = new List<Project>();

    //public ICollection<ProjectTechnology>? ProjectTechnologies { get; set; } = [];

}