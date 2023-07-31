using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IProfissionalService
    {
        void Cadastrar(Profissional Profissional);
        void Excluir(int Id);
        List<Profissional> ListarRegistros();
        Profissional RetornarRegistro (int Id);

    }
}