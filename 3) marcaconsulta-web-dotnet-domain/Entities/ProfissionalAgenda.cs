namespace marcaconsulta_web_dotnet_domain.Entities;

public class ProfissionalAgenda
{
    public int? Id {get;set;}
    public int? ProfissionalId {get;set;}
    public DateTime Data {get;set;}
    public string? HoraInicio {get;set;}
    public string? HoraFim {get;set;}
    
}
