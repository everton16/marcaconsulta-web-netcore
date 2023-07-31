using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IProfissionalAgendaService
    {
        void Cadastrar(ProfissionalAgenda ProfissionalAgenda);
        void Excluir(int Id);
        List<ProfissionalAgenda> ListarRegistros();
        ProfissionalAgenda RetornarRegistro (int Id);

    }
}