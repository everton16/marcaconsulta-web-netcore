using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface ICidadeService
    {
        void Cadastrar(Cidade Cidade);
        void Excluir(int Id);
        List<Cidade> ListarRegistros();
        Cidade RetornarRegistro (int Id);

    }
}