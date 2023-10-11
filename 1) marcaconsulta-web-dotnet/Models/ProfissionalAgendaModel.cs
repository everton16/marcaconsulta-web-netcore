
using marcaconsulta_web_dotnet_domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace marcaconsulta_web_netcore.Models
{
    public class ProfissionalAgendaModel
    {
        public int? Id {get;set;}
        public int? ProfissionalId {get;set;}
        public DateTime Data {get;set;}
        public string? HoraInicio {get;set;}
        public string? HoraFim {get;set;}

        public string? ProfissionalNome {get;set;}
        public string? ProfissionalEndereco {get;set;}
        public string? ProfissionalBairro {get;set;}
        public string? ProfissionalCidade {get;set;}

        
        public Profissional? Profissional{get;set;}
        public ProfissionalAgenda? ProfissionalAgenda {get;set;}

        public Cidade? Cidade {get;set;}
            
    }
}