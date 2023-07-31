using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public EspecialidadeService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Especialidade Especialidade)
        {
            var dbSet = _dbContext.Especialidade;

            if (Especialidade.Id == null)
            {
                dbSet.Add(Especialidade);
            
            }
            else{
                dbSet.Attach(Especialidade);
                _dbContext.Entry(Especialidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Especialidade = new Especialidade(){Id = Id};
            _dbContext.Attach(Especialidade);
            _dbContext.Remove(Especialidade);
            _dbContext.SaveChanges();
        }

        List<Especialidade> IEspecialidadeService.ListarRegistros()
        {
            var dbSet = _dbContext.Especialidade;
            return dbSet.ToList();
        }

        Especialidade IEspecialidadeService.RetornarRegistro(int Id)
        {
            return _dbContext.Especialidade.Where(x => x.Id == Id).First();
        }
    }
}