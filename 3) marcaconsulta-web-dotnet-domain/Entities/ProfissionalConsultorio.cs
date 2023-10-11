namespace marcaconsulta_web_dotnet_domain.Entities;

public class ProfissionalConsultorio
{
    public int? Id {get;set;}
    public int? ConsultorioId {get;set;}
    public int? ProfissionalId {get;set;}
    public int? PrazoCancelamento {get;set;}

    
    public Consultorio? Consultorio {get;set;}
    public Profissional? Profissional {get;set;}

}
