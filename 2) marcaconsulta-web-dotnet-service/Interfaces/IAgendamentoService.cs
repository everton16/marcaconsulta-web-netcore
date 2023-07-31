using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IAgendamentoService
    {
        void Cadastrar(Agendamento Agendamento);
        void Excluir(int Id);
        List<Agendamento> ListarRegistros();
        Agendamento RetornarRegistro (int Id);

    }
}