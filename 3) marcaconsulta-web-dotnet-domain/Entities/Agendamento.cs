namespace marcaconsulta_web_dotnet_domain.Entities;

public class Agendamento
{

    public int? Id {get;set;}
    public int? PacienteId {get;set;}
    public int? ProfissionalAgendaId {get;set;}
    
    
    public Paciente? Paciente {get;set;}

    public ProfissionalAgenda? ProfissionalAgenda {get;set;}
    
}
