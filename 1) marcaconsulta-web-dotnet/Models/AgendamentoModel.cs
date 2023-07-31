
using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_netcore.Models
{
    public class AgendamentoModel
    {
        public int? Id {get;set;}
        public int? PacienteId {get;set;}
        public int? ProfissionalAgendaId {get;set;}
        public Agendamento? Agendamento{get;set;}
    }
}