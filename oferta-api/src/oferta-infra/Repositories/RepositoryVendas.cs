using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_infra.Repositories
{
    public class RepositoryVendas : RepositoryBase<Venda>, IRepositoryVendas
    {
        public RepositoryVendas(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}