
using marcaconsulta_web_dotnet_domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace marcaconsulta_web_netcore.Models
{
    public class AgendamentoModel
    {
        public int Id {get;set;}
        public int? PacienteId {get;set;}
        public int? ProfissionalAgendaId {get;set;}
        public string? PacienteNome {get;set;}
        public string? ProfissionalNome {get;set;}

        //public DateTime ProfissionalAgendaData{get;set;}
        //public string? ProfissionalAgendaHoraInicio {get;set;}
        //public string? ProfissionalAgendaHoraFim{get;set;}
        
        
        public ProfissionalAgenda? ProfissionalAgenda {get;set;}
        public Agendamento? Agendamento{get;set;}
        public Profissional? Profissional{get;set;}
        public Paciente? Paciente{get;set;}
        public IEnumerable<SelectListItem>? ListaProfissionalAgendas {get;set;}        
        
    }
}