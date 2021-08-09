using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryEndereco : RepositoryBase<Endereco>, IRepositoryEnderecos
    {
        public RepositoryEndereco(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}