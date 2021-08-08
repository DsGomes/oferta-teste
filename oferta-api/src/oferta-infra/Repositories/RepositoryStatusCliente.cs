using System.Collections.Generic;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryStatusCliente : IRepositoryStatus
    {
        private readonly DataBaseContext _dbContext;

        public RepositoryStatusCliente(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<StatusCliente> GetStatusCliente()
        {
            return _dbContext.Set<StatusCliente>().AsQueryable();
        }
    }
}