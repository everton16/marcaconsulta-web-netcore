
using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_netcore.Models
{
    public class ProfissionalAgendaModel
    {
        public int? Id {get;set;}
        public int? ProfissionalId {get;set;}
        public DateTime Data {get;set;}
        public string? HoraInicio {get;set;}
        public string? HoraFim {get;set;}
        public ProfissionalAgenda? ProfissionalAgenda {get;set;}
    
    }
}