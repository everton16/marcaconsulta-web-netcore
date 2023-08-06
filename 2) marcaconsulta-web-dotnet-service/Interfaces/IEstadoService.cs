using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IEstadoService
    {
        void Cadastrar(Estado Estado);
        void Excluir(int Id);
        List<Estado> ListarRegistros();
        Estado RetornarRegistro (int Id);

    }
}