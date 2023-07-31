using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public ProfissionalService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Profissional Profissional)
        {
            var dbSet = _dbContext.Profissional;

            if (Profissional.Id == null)
            {
                dbSet.Add(Profissional);
            
            }
            else{
                dbSet.Attach(Profissional);
                _dbContext.Entry(Profissional).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Profissional = new Profissional(){Id = Id};
            _dbContext.Attach(Profissional);
            _dbContext.Remove(Profissional);
            _dbContext.SaveChanges();
        }

        List<Profissional> IProfissionalService.ListarRegistros()
        {
            var dbSet = _dbContext.Profissional;
            return dbSet.ToList();
        }

        Profissional IProfissionalService.RetornarRegistro(int Id)
        {
            return _dbContext.Profissional.Where(x => x.Id == Id).First();
        }
    }
}