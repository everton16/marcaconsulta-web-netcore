using Microsoft.EntityFrameworkCore;
using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_infra;


public class MarcaConsultaDbContext : DbContext

{
    public DbSet<Profissional> Profissional {get;set;}
    public DbSet<Paciente> Paciente {get;set;}
    public DbSet<Agendamento> Agendamento {get;set;}
    public DbSet<ProfissionalAgenda> ProfissionalAgenda {get;set;}
    public DbSet<Especialidade> Especialidade {get;set;}
    
    public DbSet<Cidade> Cidade {get;set;}
    public DbSet<Estado> Estado {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=marcaconsulta;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;");

    }


}
