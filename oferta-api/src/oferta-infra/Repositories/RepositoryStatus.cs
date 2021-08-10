using System.Collections.Generic;
using System.Linq;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryStatus : RepositoryBase<StatusCliente>, IRepositoryStatus
    {
        private readonly DataBaseContext _dbContext;
        public RepositoryStatus(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}