using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marcaconsulta_web_dotnet_service
{
    public class EstadoService : IEstadoService
    {
        private readonly MarcaConsultaDbContext _dbContext;
        public EstadoService (MarcaConsultaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Cadastrar(Estado Estado)
        {
            var dbSet = _dbContext.Estado;

            if (Estado.Id == null)
            {
                dbSet.Add(Estado);
            
            }
            else{
                dbSet.Attach(Estado);
                _dbContext.Entry(Estado).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }

        public void Excluir(int Id)
        {
            var Estado = new Estado(){Id = Id};
            _dbContext.Attach(Estado);
            _dbContext.Remove(Estado);
            _dbContext.SaveChanges();
        }

        List<Estado> IEstadoService.ListarRegistros()
        {
            var dbSet = _dbContext.Estado;
            return dbSet.ToList();
        }

        Estado IEstadoService.RetornarRegistro(int Id)
        {
            return _dbContext.Estado.Where(x => x.Id == Id).First();
        }
    }
}