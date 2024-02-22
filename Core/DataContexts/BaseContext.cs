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
            new Technology { Id = 51, Name = "PHP" },
            new Technology { Id = 52, Name = "Nest.js" }
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

            // IdeaIT
            new Project { Id = 1, Name = "Realizzazione Sito ShareLock", Description = """Realizzazione e implementazione tema custom compatibile con il software Elementor, manutenzione generale sui contenuti e sulla sicurezza""", Start = DateTime.Parse("2019-04-03"), End = DateTime.Parse("2019-07-14"), CompanyId = 1 },

            // GSE
            new Project { Id = 2, Name = "Realizzazione Gestionale SuiteCRM", Description = """Ricostruzione dell'intero ambiente da zero con moduli custom, implementazione di funzionalità di WorkFlow, configurazione per il corretto utilizzo delle cartelle di posta essoteriche Exchange e riadattamenti vari per consentire la corretta comunicazione con il Database SQL Server""", Start = DateTime.Parse("2021-06-03"), End = DateTime.Parse("2021-12-14"), CompanyId = 2 },

            // BIP
            new Project { Id = 3, Name = "Realizzazione Applicativo Tableau De Bord", Description = """Portale con frontend in Vue.js che offre ai suoi utenti dei grafici sull'andamento delle attività e turni lavorativi""", Start = DateTime.Parse("2020-06-16"), End = DateTime.Parse("2021-01-17"), CompanyId = 2 },

            new Project { Id = 4, Name = "Realizzazione Applicativo Bacheca", Description = """Portale con frontend in Vue.js che offre ai suoi utenti un'interfaccia per consultare le novità e un classico CRUD amministrativo per la gestione dei contenuti""", Start = DateTime.Parse("2020-08-04"), End = DateTime.Parse("2020-10-11"), CompanyId = 2 },

            // Sogeit
            new Project { Id = 5, Name = "Revisione Applicativo Netbook", Description = """Implementazione funzionalità di generazione ed esportazione di carte topografiche, manutenzione generale""", Start = DateTime.Parse("2020-09-02"), End = DateTime.Parse("2021-03-17"), CompanyId = 2 },

            new Project { Id = 6, Name = "Revisione Applicativo NewsletterPro", Description = """Potenziamento e ottimizzazione delle funzionalità di scheduling email""", Start = DateTime.Parse("2020-09-18"), End = DateTime.Parse("2020-12-19"), CompanyId = 2 },

            new Project { Id = 7, Name = "Revisione Applicativo SmallApp", Description = """Creazione scheduling invio SMS in diverse lingue, implementazione funzionalità per l'automatizzazione del flusso, manutenzione generale sulla sicurezza""", Start = DateTime.Parse("2020-08-08"), End = DateTime.Parse("2021-06-09"), CompanyId = 2 },

            new Project { Id = 8, Name = "Revisione Applicativo ASM", Description = """Aggiunta di funzionalità e bugfix vari""", Start = DateTime.Parse("2020-09-25"), End = DateTime.Parse("2021-02-01"), CompanyId = 2 },

            new Project { Id = 9, Name = "Revisione Sito Operazione Risorgimento Digitale", Description = """Manutenzione generale, aggiunta di contenuti, creazione di un modulo custom""", Start = DateTime.Parse("2021-03-22"), End = DateTime.Parse("2021-10-21"), CompanyId = 2 },

            new Project { Id = 10, Name = "Realizzazione Sito TIM Ventures", Description = """Creazione di un sito multilingua con tema custom, modulo custom e blocchi custom editabili da pannello di amministrazione""", Start = DateTime.Parse("2021-04-04"), End = DateTime.Parse("2021-04-25"), CompanyId = 2 },

            new Project { Id = 11, Name = "Rifacimento Sito TIM Operazione Risorgimento Digitale", Description = """Creazione e manutenzione di un sito con tipi di contenuto filtrabili, editabili e gestibili dall'utente amministratore tramite blocchi di paragrafi e viste custom, logica di sottoscrizione a corsi, creazione di moduli custom""", Start = DateTime.Parse("2021-10-14"), End = DateTime.Parse("2022-04-12"), CompanyId = 2 },

            // Foodlovery
            new Project { Id = 12, Name = "Food Delivery", Description = """Implementazione sistema di notifiche E-Mail e OneSignal, con pannello gestionale lato web-app in base al tipo notifica e ruolo d'appartenenza, e piattaforma di messaggistica tramite ChatBot full-stack (Ionic per le tre app mobile, Angular per la web-app e NestJS per il Backend) per la risoluzione degli ordini non completati. Risoluzione di criticità varie presenti sulle quattro app frontend e riadattamento del sistema di geolocalizzazione tramite le API di Google Maps""", Start = DateTime.Parse("2022-02-06"), End = DateTime.Parse("2022-04-18"), CompanyId = 2 },

            // Deep Consulting
            new Project { Id = 13, Name = "Console Regia", Description = """Ricostruzione in Angular 11 di un applicativo Flash finalizzato alla gestione smart dei disservizi e implementazione di nuove funzionalità custom volte al filtraggio avanzato, alla visualizzazione di grafici statistici e all'esportazione dei dati intabellati in formato XLS. Prima bozza dell'applicativo costruita mediante l'utilizzo della libreria NGBootstrap, versione corrente mediante PrimeNG""", Start = DateTime.Parse("2021-10-27"), End = DateTime.Parse("2022-02-03"), CompanyId = 2 },

            new Project { Id = 14, Name = "Intranet", Description = """Progettazione e sviluppo, nel contesto del Sistema informativo Aziendale interno, di una piattaforma software per la gestione del recruiting, delle richieste di lavoro, CV e degli skill matrix aziendali, con sistema di notifiche basato su Websockets, integrazione con le API di Google per lo scheduling dei colloqui da remoto e con Google Drive per il salvataggio di documenti importanti sul Cloud. Il backend è stato scritto in ambiente Linux / Apache e consta di un set di API RESTful sviluppate con l'ausilio di Laravel; la versione attuale del frontend in Angular 12 sviluppata con l'ausilio di Bulma e la libreria di componenti DevExtreme, la prima versione in Vue.js/Bootstrap 4. La Web App è stata realizzata con l'ausilio di Capacitor per il rilascio delle versioni Desktop Electron, Android e iOS.""", Start = DateTime.Parse("2020-12-03"), End = DateTime.Parse("2023-01-17"), CompanyId = 2 },

            // Livebox
            new Project { Id = 15, Name = "VDesk - Taranto", Description = """Realizzazione di un plugin full-stack “scadenziario” per l'app Angular 9 VDesk (Material - Syncfusion), con Backend Nextcloud 17 (PHP 7.3) e Bridge Laravel 6.2""", Start = DateTime.Parse("2022-03-18"), End = DateTime.Parse("2022-04-11"), CompanyId = 2 },

            new Project { Id = 16, Name = "VDesk - Bologna", Description = """Realizzazione di un plugin full-stack per l'interfacciamento con un secondo DB esterno, con CRUD di tabelle/campi/relazioni e un'interfaccia frontend simil-phpMyAdmin. Realizzazione di un sistema di auto-provisioning degli utenti SAML importati dal cliente su tabelle di appoggio presenti un secondo DB esterno. Realizzazione di un plugin per la visualizzazione tramite menù a tendina condizionali delle informazioni presenti sull'area di staging all'interno del WorkFlow Builder, al fine di garantirne la fruibilità lato utente tramite campi compilabili dinamici. Implementazione di logica sottesa all'area di staging, finalizzata alla categorizzazione dinamica dei dati recuperati dai menù a tendina a seconda del gruppo di appartenenza dell'utente, fornendo all'editor del template la possibilità di specificare da backoffice una condizione di recupero dati per ogni gruppo esistente. Revisione della struttura logica del WorkFlow Builder volta all'implementazione e alla gestione di condizionalità di flusso, fornendo all'utente richiedente la possibilità di scegliere i gruppi destinatari della sua pratica su ogni RuoloFase specificato in backoffice tra una lista autopopolata di gruppi dipendenti dal proprio responsabile approvativo SAML. Implementazione di una casistica “flusso semplificato” per la gestione di richieste indipendenti dall'andamento del WorkFlow, che vengono convertite in PDF e inviate a uno o più indirizzi di posta elettronica come indicato in backoffice. Risoluzione di alcune criticità sulla parte di autenticazione SAML, display feed RSS, validazione elementi richiesta, personalizzazione email/messaggi notifiche e implementazione di funzionalità di ordinamento dati importati tramite CSV sui menù a tendina""", Start = DateTime.Parse("2022-04-12"), End = DateTime.Parse("2022-10-02"), CompanyId = 2 },

            // TeamSystem
            new Project { Id = 17, Name = "Presenze/Polyedro/AllInOne", Description = """Manutenzione generale, porting e nuove implementazioni su un macroapplicativo consolidato per il censimento dei dati anagrafici e verifiche sullo stato di attività della popolazione multiaziendale, gestione trasferte e registrazione contabile note spesa, elaborazione timbrature di presenza e produzione valorizzate da cartellino, pianificazione orari di lavoro, turni e allocazioni su reparti con ribaltamento diretto dei dati approvati su timesheet. Sviluppo di un applicativo in C per il recupero delle informazioni riguardanti sistema operativo, macchina e installazione sugli impianti on-premise. Ripensamento della logica di funzionamento e riscrittura del vecchio workflow autorizzativo delle giustificazioni via mail da C in C++, per consentire l'autorizzazione massiva automatica di un numero elevato di giustificativi in tempo reale. Sviluppo di servizi C++ per l'esposizione di dati su visibilità gerarchica del proprio team di lavoro verso App Mobile, sistemi SAP e dashboard esterne gestite dai clienti. Previsione di uno script per l'esportazione e il seeding di un preset di dati per agevolare l'installazione dei nuovi tenant cloud. Supporto all'analisi di un sistema di import parametrico preesistente in C++ per la messa in piedi della sua controparte di export in Python. Parte legacy sviluppata in C/Javascript, moderna con backend C++, Bridge Java 8 e frontend Angular 14.""", Start = DateTime.Parse("2022-09-14"), End = DateTime.Parse("2024-01-14"), CompanyId = 2 }

        );
    }

    private void seedProjectTechnologies(ModelBuilder modelBuilder) {
        // TODO enum fixed Technologies, base Projects
         modelBuilder.Entity("ProjectTechnology").HasData(
            // ShareLock
            new { ProjectsId = 1, TechnologiesId = 3 },
            new { ProjectsId = 1, TechnologiesId = 51 },

            // GSE SuiteCRM
            new { ProjectsId = 2, TechnologiesId = 45 },
            new { ProjectsId = 2, TechnologiesId = 51 },
            new { ProjectsId = 2, TechnologiesId = 16 },

            // Tableau
            new { ProjectsId = 3, TechnologiesId = 11 },
            new { ProjectsId = 3, TechnologiesId = 16 },
            new { ProjectsId = 3, TechnologiesId = 18 },
            new { ProjectsId = 3, TechnologiesId = 19 },
            new { ProjectsId = 3, TechnologiesId = 20 },
            new { ProjectsId = 3, TechnologiesId = 38 },
            new { ProjectsId = 3, TechnologiesId = 51 },

            // Bacheca
            new { ProjectsId = 4, TechnologiesId = 11 },
            new { ProjectsId = 4, TechnologiesId = 16 },
            new { ProjectsId = 4, TechnologiesId = 18 },
            new { ProjectsId = 4, TechnologiesId = 19 },
            new { ProjectsId = 4, TechnologiesId = 20 },
            new { ProjectsId = 4, TechnologiesId = 38 },
            new { ProjectsId = 4, TechnologiesId = 51 },

            // Netbook
            new { ProjectsId = 5, TechnologiesId = 4 },
            new { ProjectsId = 5, TechnologiesId = 40 },
            new { ProjectsId = 5, TechnologiesId = 41 },

            // NewsletterPro
            new { ProjectsId = 6, TechnologiesId = 4 },

            // SmallApp
            new { ProjectsId = 7, TechnologiesId = 4 },

            // ASM
            new { ProjectsId = 8, TechnologiesId = 4 },

            // ORD review
            new { ProjectsId = 9, TechnologiesId = 4 },

            // Ventures
            new { ProjectsId = 10, TechnologiesId = 4 },

            // ORD remake
            new { ProjectsId = 11, TechnologiesId = 4 },

            // Foodlovery
            
            new { ProjectsId = 12, TechnologiesId = 1 },
            new { ProjectsId = 12, TechnologiesId = 30 },
            new { ProjectsId = 12, TechnologiesId = 42 },
            new { ProjectsId = 12, TechnologiesId = 52 },

            // Console regia
            new { ProjectsId = 13, TechnologiesId = 1 },
            new { ProjectsId = 13, TechnologiesId = 5 },
            new { ProjectsId = 13, TechnologiesId = 39 },

            // Intranet
            new { ProjectsId = 14, TechnologiesId = 1 },
            new { ProjectsId = 14, TechnologiesId = 2 },
            new { ProjectsId = 14, TechnologiesId = 11 },
            new { ProjectsId = 14, TechnologiesId = 18 },
            new { ProjectsId = 14, TechnologiesId = 48 },
            new { ProjectsId = 14, TechnologiesId = 49 },
            new { ProjectsId = 14, TechnologiesId = 50 },

            // VDesk Taranto
            new { ProjectsId = 15, TechnologiesId = 1 },
            new { ProjectsId = 15, TechnologiesId = 2 },
            new { ProjectsId = 15, TechnologiesId = 20 },
            new { ProjectsId = 15, TechnologiesId = 33 },
            new { ProjectsId = 15, TechnologiesId = 34 },
            new { ProjectsId = 15, TechnologiesId = 38 },
            new { ProjectsId = 15, TechnologiesId = 43 },
            new { ProjectsId = 15, TechnologiesId = 44 },

            // VDesk Bologna
            new { ProjectsId = 16, TechnologiesId = 1 },
            new { ProjectsId = 16, TechnologiesId = 2 },
            new { ProjectsId = 16, TechnologiesId = 20 },
            new { ProjectsId = 16, TechnologiesId = 33 },
            new { ProjectsId = 16, TechnologiesId = 34 },      
            new { ProjectsId = 16, TechnologiesId = 38 },
            new { ProjectsId = 16, TechnologiesId = 43 },
            new { ProjectsId = 16, TechnologiesId = 44 },

            // TeamSystem
            new { ProjectsId = 17, TechnologiesId = 1 },
            new { ProjectsId = 17, TechnologiesId = 6 },
            new { ProjectsId = 17, TechnologiesId = 7 },  
            new { ProjectsId = 17, TechnologiesId = 8 },
            new { ProjectsId = 17, TechnologiesId = 9 },
            new { ProjectsId = 17, TechnologiesId = 13 },
            new { ProjectsId = 17, TechnologiesId = 28 },
            new { ProjectsId = 17, TechnologiesId = 29 },
            new { ProjectsId = 17, TechnologiesId = 31 }
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
            new User { UserName = "user4", FirstName = "Noah", LastName = "Brown", Email = "noah.brown@mail.com" },
            new User { UserName = "simone.tenisci", FirstName = "Simone", LastName = "Tenisci", Email = "simone.tenisci@r2u.it" }
        );
    }

}

