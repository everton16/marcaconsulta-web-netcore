namespace marcaconsulta_web_dotnet_domain.Entities;

public class Consultorio
{

    public int Id {get;set;}
    public string? NomeConsultorio {get;set;}
    public string? Endereco {get;set;}
    public int? CidadeId {get;set;}
    public string? Bairro {get;set;}
    public string? Cep {get;set;}
    public string? Telefone {get;set;}
    
    public Cidade? Cidade {get;set;}

}
