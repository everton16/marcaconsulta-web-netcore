using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class CidadeService : ICidadeService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public CidadeService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Cidade Cidade)
        {
            var dbSet = _dbContext.Cidade;

            if (Cidade.Id == null)
            {
                dbSet.Add(Cidade);
            
            }
            else{
                dbSet.Attach(Cidade);
                _dbContext.Entry(Cidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Cidade = new Cidade(){Id = Id};
            _dbContext.Attach(Cidade);
            _dbContext.Remove(Cidade);
            _dbContext.SaveChanges();
        }

        List<Cidade> ICidadeService.ListarRegistros()
        {
            var dbSet = _dbContext.Cidade;
            return dbSet.ToList();
        }

        Cidade ICidadeService.RetornarRegistro(int Id)
        {
            return _dbContext.Cidade.Where(x => x.Id == Id).First();
        }
    }
}