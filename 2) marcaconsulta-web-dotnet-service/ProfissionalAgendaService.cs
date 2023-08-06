using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class ProfissionalAgendaService : IProfissionalAgendaService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public ProfissionalAgendaService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(ProfissionalAgenda ProfissionalAgenda)
        {
            var dbSet = _dbContext.ProfissionalAgenda;

            if (ProfissionalAgenda.Id == null)
            {
                dbSet.Add(ProfissionalAgenda);
            
            }
            else{
                dbSet.Attach(ProfissionalAgenda);
                _dbContext.Entry(ProfissionalAgenda).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var ProfissionalAgenda = new ProfissionalAgenda(){Id = Id};
            _dbContext.Attach(ProfissionalAgenda);
            _dbContext.Remove(ProfissionalAgenda);
            _dbContext.SaveChanges();
        }

        List<ProfissionalAgenda> IProfissionalAgendaService.ListarRegistros()
        {
            var dbSet = _dbContext.ProfissionalAgenda.Include(x => x.Profissional).ThenInclude(y=>y.Cidade);
            return dbSet.ToList();
        }

        ProfissionalAgenda IProfissionalAgendaService.RetornarRegistro(int Id)
        {
            return _dbContext.ProfissionalAgenda.Where(x => x.Id == Id).First();
        }
    }
}