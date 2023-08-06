using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class PacienteService : IPacienteService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public PacienteService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Paciente Paciente)
        {
            var dbSet = _dbContext.Paciente;

            if (Paciente.Id == null)
            {
                dbSet.Add(Paciente);
            
            }
            else{
                dbSet.Attach(Paciente);
                _dbContext.Entry(Paciente).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Paciente = new Paciente(){Id = Id};
            _dbContext.Attach(Paciente);
            _dbContext.Remove(Paciente);
            _dbContext.SaveChanges();
        }

        List<Paciente> IPacienteService.ListarRegistros()
        {
            var dbSet = _dbContext.Paciente.Include(x=>x.Cidade).ThenInclude(y=>y.Estado);
            return dbSet.ToList();
        }

        Paciente IPacienteService.RetornarRegistro(int Id)
        {
            return _dbContext.Paciente.Where(x => x.Id == Id).First();
        }
    }
}