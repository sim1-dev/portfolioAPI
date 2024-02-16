using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Core.DataContexts;
public class BaseContext: IdentityDbContext {
    public BaseContext() {
    }
    public BaseContext(DbContextOptions<BaseContext> options) : base(options){  
    }

    public new DbSet<User> Users { get; set; }
    public new DbSet<Role> Roles { get; set; }
    public DbSet<Company> Companies {get; set;}
    public DbSet<Technology> Technologies { get; set;}
    public DbSet<Project> Projects {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        seed(modelBuilder);
    }

    private void seed(ModelBuilder modelBuilder)
    {
        seedRoles(modelBuilder);
        seedUsers(modelBuilder);
        seedTechnologies(modelBuilder);
        seedCompanies(modelBuilder);
        seedProjects(modelBuilder);
        seedProjectTechnologies(modelBuilder);
    }

    private void seedTechnologies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technology>().HasData(
            new Technology { Id = 1, Name = "Angular" },
            new Technology { Id = 2, Name = "Laravel" },
            new Technology { Id = 3, Name = "Wordpress" },
            new Technology { Id = 4, Name = "Drupal" },
            new Technology { Id = 5, Name = "C#" },
            new Technology { Id = 6, Name = "Java" },
            new Technology { Id = 7, Name = "C++" },
            new Technology { Id = 8, Name = "Python" },
            new Technology { Id = 9, Name = "JavaScript" },
            new Technology { Id = 10, Name = "React" },
            new Technology { Id = 11, Name = "Vue" },
            new Technology { Id = 13, Name = "SQL Server" },
            new Technology { Id = 14, Name = "PostgreSQL" },
            new Technology { Id = 16, Name = "MySQL" },
            new Technology { Id = 18, Name = "Redis" },
            new Technology { Id = 19, Name = "RabbitMQ" },
            new Technology { Id = 20, Name = "Docker" },
            new Technology { Id = 21, Name = "Kubernetes" },
            new Technology { Id = 22, Name = "AWS" },
            new Technology { Id = 23, Name = "Azure" },
            new Technology { Id = 26, Name = "SVN" },
            new Technology { Id = 28, Name = "Jira" },
            new Technology { Id = 29, Name = "C" },
            new Technology { Id = 30, Name = "Ionic" },
            new Technology { Id = 31, Name = "SAP" },
            new Technology { Id = 32, Name = "Typescript" },
            new Technology { Id = 33, Name = "NextCloud" },
            new Technology { Id = 34, Name = "Material" },
            new Technology { Id = 35, Name = "Tailwind" },
            new Technology { Id = 36, Name = "Bootstrap" },
            new Technology { Id = 37, Name = "SASS" },
            new Technology { Id = 38, Name = "Syncfusion" },
            new Technology { Id = 39, Name = "PrimeNG" },
            new Technology { Id = 40, Name = "Leaflet.js" },
            new Technology { Id = 41, Name = "OpenStreetMap" },
            new Technology { Id = 42, Name = "Google Maps" },
            new Technology { Id = 43, Name = "SAML" },
            new Technology { Id = 44, Name = "LDAP" },
            new Technology { Id = 45, Name = "SuiteCRM" },
            new Technology { Id = 46, Name = "Websockets" },
            new Technology { Id = 47, Name = "Three.js" },
            new Technology { Id = 48, Name = "Electron" },
            new Technology { Id = 49, Name = "Cordova" },
            new Technology { Id = 50, Name = "Capacitor" },
            new Technology { Id = 51, Name = "PHP" }
        );
    }

    private void seedCompanies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "IdeaIT S.r.l.", Start = DateTime.Parse("2019-04-03"), End = DateTime.Parse("2019-07-14") },
            new Company { Id = 2, Name = "Ready2Use S.r.l.", Start = DateTime.Parse("2020-06-05") }
        );
    }

    private void seedProjects(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(

            new Project { Id = 1, Name = "Realizzazione Sito ShareLock", Description = """Realizzazione e implementazione tema custom compatibile con il software Elementor, manutenzione generale sui contenuti e sulla sicurezza""", Start = DateTime.Parse("2019-04-03"), End = DateTime.Parse("2019-07-14"), CompanyId = 1 },

            new Project { Id = 2, Name = "Realizzazione Gestionale SuiteCRM", Description = """Ricostruzione dell'intero ambiente da zero con moduli custom, implementazione di funzionalità di WorkFlow, configurazione per il corretto utilizzo delle cartelle di posta essoteriche Exchange e riadattamenti vari per consentire la corretta comunicazione con il Database SQL Server""", Start = DateTime.Parse("2021-06-03"), End = DateTime.Parse("2021-12-14"), CompanyId = 2 },

            new Project { Id = 3, Name = "Realizzazione Applicativo Tableau De Bord", Description = """Portale con frontend in Vue.js che offre ai suoi utenti dei grafici sull'andamento delle attività e turni lavorativi""", Start = DateTime.Parse("2020-06-16"), End = DateTime.Parse("2021-01-17"), CompanyId = 2 },

            new Project { Id = 4, Name = "Realizzazione Applicativo Bacheca", Description = """Portale con frontend in Vue.js che offre ai suoi utenti un'interfaccia per consultare le novità e un classico CRUD amministrativo per la gestione dei contenuti""", Start = DateTime.Parse("2020-08-04"), End = DateTime.Parse("2020-10-11"), CompanyId = 2 }
        );
    }

    private void seedProjectTechnologies(ModelBuilder modelBuilder) {
         modelBuilder.Entity("ProjectTechnology").HasData(
            new { ProjectsId = 1, TechnologiesId = 3 },
            new { ProjectsId = 1, TechnologiesId = 51 }
        );
    }

    private void seedRoles(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Role>().HasData(
            new Role { Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Name = "Editor", NormalizedName = "Editor" },
            new Role { Name = "User", NormalizedName = "User" }
        );
    }

    private void seedUsers(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasData(
            new User { UserName = "user1", FirstName = "Emma", LastName = "Stone", Email = "emma.stone@mail.com" },
            new User { UserName = "user2", FirstName = "Liam", LastName = "Smith", Email = "liam.smith@mail.com" },
            new User { UserName = "user3", FirstName = "Olivia", LastName = "Jones", Email = "olivia.jones@mail.com" },
            new User { UserName = "user4", FirstName = "Noah", LastName = "Brown", Email = "noah.brown@mail.com" }
        );
    }

}

