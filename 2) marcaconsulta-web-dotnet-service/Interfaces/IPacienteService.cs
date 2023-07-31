using marcaconsulta_web_dotnet_domain.Entities;

namespace marcaconsulta_web_dotnet_service.Interfaces
{
    public interface IPacienteService
    {
        void Cadastrar(Paciente Paciente);
        void Excluir(int Id);
        List<Paciente> ListarRegistros();
        Paciente RetornarRegistro (int Id);

    }
}