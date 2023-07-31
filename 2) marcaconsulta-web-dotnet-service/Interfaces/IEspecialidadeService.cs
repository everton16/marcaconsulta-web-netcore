using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IEspecialidadeService
    {
        void Cadastrar(Especialidade Especialidade);
        void Excluir(int Id);
        List<Especialidade> ListarRegistros();
        Especialidade RetornarRegistro (int Id);

    }
}