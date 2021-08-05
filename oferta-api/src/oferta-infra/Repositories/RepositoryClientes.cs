using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_infra.Repositories
{
    public class RepositoryClientes : RepositoryBase<Cliente>, IRepositoryClientes
    {
        public RepositoryClientes(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}