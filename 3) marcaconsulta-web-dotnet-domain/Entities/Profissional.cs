namespace marcaconsulta_web_dotnet_domain.Entities;

public class Profissional
{

    public int? Id {get;set;}
    public string? Cpf {get;set;}
    public string? Nome {get;set;}
    public string? Telefone {get;set;}
    public string? Endereco {get;set;}
    public string? Bairro {get;set;}
    public int? CidadeId {get;set;}
    public int? EspecialidadeId {get;set;}

    public Cidade? Cidade {get;set;}
    public Especialidade? Especialidade {get;set;}
    //public Estado? Estado {get;set;}
}
