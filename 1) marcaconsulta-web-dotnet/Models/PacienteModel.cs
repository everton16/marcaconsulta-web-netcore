
using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_netcore.Models
{
    public class PacienteModel
    {
        public int? Id {get;set;}
        public string? Cpf {get;set;}
        public string? Nome {get;set;}
        public string? Telefone {get;set;}
        public string? Endereco {get;set;}
        public string? Bairro {get;set;}
        public int? CidadeId {get;set;}
        public string? CidadeNome {get;set;}
        public string? EstadoNome{get;set;}

        
        
        Paciente? Paciente {get;set;}
    }
}