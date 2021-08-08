using oferta_domain.Entities;
using oferta_domain.Interfaces;

namespace oferta_infra.Repositories
{
    public class RepositoryProdutos : RepositoryBase<Produto>, IRepositoryProdutos
    {
        public RepositoryProdutos(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}