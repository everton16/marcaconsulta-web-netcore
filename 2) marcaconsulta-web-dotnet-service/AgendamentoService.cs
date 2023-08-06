using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public AgendamentoService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Agendamento Agendamento)
        {
            var dbSet = _dbContext.Agendamento;

            if (Agendamento.Id == null)
            {
                dbSet.Add(Agendamento);
            
            }
            else{
                dbSet.Attach(Agendamento);
                _dbContext.Entry(Agendamento).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Agendamento = new Agendamento(){Id = Id};
            _dbContext.Attach(Agendamento);
            _dbContext.Remove(Agendamento);
            _dbContext.SaveChanges();
        }

        List<Agendamento> IAgendamentoService.ListarRegistros()
        {
            var dbSet = _dbContext.Agendamento.Include(w => w.ProfissionalAgenda).ThenInclude(x=>x.Profissional);
            return dbSet.ToList();
        }

        Agendamento IAgendamentoService.RetornarRegistro(int Id)
        {
            return _dbContext.Agendamento.Where(x => x.Id == Id).First();
        }
    }
}