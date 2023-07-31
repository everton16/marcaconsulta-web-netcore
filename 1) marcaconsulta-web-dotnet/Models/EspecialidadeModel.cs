
using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_netcore.Models
{
    public class EspecialidadeModel
    {
        public int? Id {get;set;}
        public string? TextoEspecialidade {get;set;}

        public Especialidade? Especialidade {get;set;}
    }
}