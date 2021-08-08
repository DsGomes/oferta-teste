using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryEndereco : RepositoryBase<Endereco>, IRepositoryEnderecos
    {
        private readonly DataBaseContext _dbContext;

        public RepositoryEndereco(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}