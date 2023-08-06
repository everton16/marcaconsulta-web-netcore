
using marcaconsulta_web_dotnet_domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace marcaconsulta_web_netcore.Models
{
    public class ProfissionalModel
    {
        public int? Id {get;set;}
        public string? Cpf {get;set;}
        public string? Nome {get;set;}
        public string? Telefone {get;set;}
        public string? Endereco {get;set;}
        public string? Bairro {get;set;}
        public int? CidadeId {get;set;}
        //public int? UfId {get;set;}
        public int? EspecialidadeId {get;set;}

        public string? CidadeNome {get;set;}
        public string? EstadoNome{get;set;}

        public Agendamento? Agendamento{get;set;}

        public Profissional? Profissional {get;set;}
        //public Especialidade? Especialidade {get;set;}
        public IEnumerable<SelectListItem>? ListaEspecialidades {get;set;}
    }
}